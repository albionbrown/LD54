using Godot;
using System;

public partial class Main : Node2D
{

	private bool GameStarted;

	private Room CurrentRoom;

	private Room[] CompletedRooms;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GameStarted = false;
		CurrentRoom = null;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (GameStarted) {

		}
	}

	public void _on_start_button_pressed() {
		GameStarted = true;
		GetTree().ChangeSceneToFile("res://Level1.tscn");
		OpenNextDoor();
	}

	public void OpenNextDoor() {

		// If it's the first roomo
		if (CurrentRoom == null) {
			// CurrentRoom = 
		}
		CompletedRooms[CompletedRooms.Length] = CurrentRoom;

		
	}
}
