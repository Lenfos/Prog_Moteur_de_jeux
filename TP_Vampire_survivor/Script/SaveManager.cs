using Godot;
using System;
using System.IO;
using System.Text.Json.Nodes;
using Godot.Collections;
using FileAccess = System.IO.FileAccess;

public partial class SaveManager : Node
{
	private static SaveManager instance;
	public static SaveManager Get(){
		if (instance == null){
			instance = new();
		}
		return instance;
	}
	
	public void LoadGame()
	{
		if (!Godot.FileAccess.FileExists("user://savefile.json"))
		{
			return;
		}

		var saveNode = Manager.Get().GetNodesInGroup("Saveable");

		using var saveFile = Godot.FileAccess.Open("user://savefile.json", Godot.FileAccess.ModeFlags.Read);

		while (saveFile.GetPosition() < saveFile.GetLength())
		{
			var jsonString = saveFile.GetLine();
			
			var jsonData = new Json();
			var parseResult = jsonData.Parse(jsonString);
			if (parseResult != Error.Ok)
			{
				continue;
			}
			
			var nodeDatas = new Godot.Collections.Dictionary<string, Variant>((Godot.Collections.Dictionary)jsonData.Data);
			
			GD.Print(Manager.Get().Root.GetNode(nodeDatas["filename"].ToString()));
			
			Manager.Get().Root.GetNode(nodeDatas["filename"].ToString()).Call("Load", nodeDatas);
		}
	}
	
	public void SaveGame()
	{
		using var saveFile = Godot.FileAccess.Open("user://savefile.json", Godot.FileAccess.ModeFlags.Write);
		
		var savedNodes = Manager.Get().GetNodesInGroup("Saveable");
		foreach (var node in savedNodes)
		{
			if (string.IsNullOrEmpty(node.SceneFilePath))
			{
				continue;
			}

			if (!node.HasMethod("Save"))
			{
				continue;
			}

			var savedDatas = node.Call("Save");

			var jsonString = Json.Stringify(savedDatas);

			saveFile.StoreLine(jsonString);
		}
	}
}
