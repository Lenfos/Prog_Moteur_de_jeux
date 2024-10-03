using Godot;
using System;

public partial class SaveManager : Node
{
	private static SaveManager instance;
	public static SaveManager Get(){
		if (instance == null){
			instance = new();
		}
		return instance;
	}
	
	public void LoadGame(string path){
		
	}
	
	public void SaveGame(string path){
		
	}
}
