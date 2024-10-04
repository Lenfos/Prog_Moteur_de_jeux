using Godot;
using System;

public partial class LevelManager : Node
{
	private const string PATH = "res://Scene/Level/";
	
	private static LevelManager instance;
	
	public static LevelManager Get(){
		if (instance == null){
			instance = new LevelManager();
		}
		return instance;
	}
	
	public void LoadLevel(string levelName){
		Node scene = ResourceLoader.Load<PackedScene>(PATH + levelName + ".tscn").Instantiate();
		Manager.Get().Root.AddChild(scene);
	}
}
