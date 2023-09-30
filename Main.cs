using Godot;
using System;

public partial class Main : Node2D
{

	private bool gameStarted;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		gameStarted = false;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (gameStarted) {

		}
	}

	public void _on_start_button_pressed() {
		GetTree().ChangeSceneToFile("res://Level1.tscn");
	}
}
