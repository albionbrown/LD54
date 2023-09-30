using Godot;
using System;

public partial class Main : Node2D
{

	private bool GameStarted;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GameStarted = false;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void _on_start_button_pressed()
	{
		GameStarted = true;
		
		// Open the first level
		GetTree().ChangeSceneToFile("res://Level1.tscn");

		// @todo play music
		
	}
}
