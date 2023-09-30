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

		Completed = false;

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
	public void PlayerEnters() 
	{

		
	}

	public void DisplayRoomName() 
	{
		Level level = (Level)GetParent();
		level.SetRoomName(Name);
	}

	public void OpenDoor(int doorNumber) {

		// In the UI, we start from 1 in the node's name.
		doorNumber++;
		Door door = (Door)GetNode<Node2D>("Door" + doorNumber);
		if (door != null) {

			door.SetOpen();
		}
	}

	public void CompleteRoom()
	{
		Completed = true;
	}

	public void _on_room_area_body_entered(Node2D body) 
	{
		if (body.IsInGroup("Player")) {
			if (!Completed) {
				DisplayRoomName();
			}
			
			PlayerEnters();
		}
	}
}
