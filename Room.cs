using Godot;
using System;

public partial class Room : TileMap
{

	[Export]
	private String Name;

	private bool Completed;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{


	}

	// Display the room name
	public void PlayerEnters() {

		// @todo display name

	}

	public void OpenDoor(int doorNumber) {
		StaticBody2D door = GetNode<StaticBody2D>("Door" + doorNumber);
		if (door != null) {
			// door.GetNode<CollisionObject2D>()
		}
	}

	public void completed() {
		Completed = true;
	}
}
