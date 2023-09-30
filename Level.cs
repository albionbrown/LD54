using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class Level : Node
{

	protected List<Room> Rooms;

	protected RichTextLabel RoomNameLabel;

	private Room CurrentRoom;

	private Room[] CompletedRooms;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		var children = GetChildren();
		Rooms = new List<Room>();
		
		foreach (Node node in children) {
			if (node.IsInGroup("Rooms")) {
				Rooms.Add((Room)node);
			}
		}

		RoomNameLabel = GetNode<RichTextLabel>("RoomName");
		RoomNameLabel.Hide();

		Timer startTimer = GetNode<Timer>("OpenFirstDoorTimer");
		startTimer.Start();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void OpenFirstDoor() 
	{
		Room firstRoom = Rooms[0];
		firstRoom.OpenDoor(0);
	}

	public void SetRoomName(String roomName)
	{
		RoomNameLabel.Text = roomName;
		RoomNameLabel.Show();
	}

	public void _on_start_timer_timeout() {
		OpenFirstDoor();
	}
}
