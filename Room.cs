using Godot;
using System;
using System.Collections.Generic;

public partial class Room : TileMap
{

	[Export]
	protected String Name;

	protected List<Door> Doors;

	private bool Completed;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		var children = GetChildren();
		Doors = new List<Door>();

		foreach(Node node in children) {
			if (node.IsInGroup("Doors")) {
				Doors.Add((Door)node);
			}
		}
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

		// In the UI, we start from 1 in the node's name.
		doorNumber++;
		Door door = (Door)GetNode<Node2D>("Door" + doorNumber);
		if (door != null) {

			// Change the door's tile to open it.
			door.SetOpen();

			// Set the door's collision object to be disabled.
			// CollisionShape2D doorCollision = door.GetNode<CollisionShape2D>("CollisionShape2D");
			// door.ProcessMode = ;
			// doorCollision.SetDeferred("Disabled", true);
			// // doorCollision.Disabled = false;
			// door.Hide();
		}
	}

	public void CompleteRoom() {
		Completed = true;
	}
}
