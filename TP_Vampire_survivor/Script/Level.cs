using Godot;
using System;

public partial class Level : Node2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Manager.Get().GetSaveManager().LoadGame();
		Manager.Get().CreateTimer(10).Timeout += saveGame;
	}

	public void saveGame()
	{
		GD.Print("Saving game");
		Manager.Get().GetSaveManager().SaveGame();
	}
	
}
