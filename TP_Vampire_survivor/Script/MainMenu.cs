using Godot;
using System;

public partial class MainMenu : Control
{
	public override void _Ready()
	{
		GD.Print("Ok");
		GetNode<Button>("MarginContainer/VBoxContainer/Play").Pressed += OnPlayPressed;
		GetNode<Button>("MarginContainer/VBoxContainer/Options").Pressed += OnOptionPressed;
		GetNode<Button>("MarginContainer/VBoxContainer/Quit").Pressed += OnQuitPressed;
	}

	private void OnQuitPressed()
	{
		GetTree().Quit();
	}

	private void OnOptionPressed()
	{
		GD.Print("Options Pressed");
	}

	private void OnPlayPressed()
	{
		GD.Print("Play pressed");
	}
}
