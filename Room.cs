using Godot;
using System;
using System.Collections.Generic;

public partial class Room : TileMap
{

	[Export]
	protected String RoomName;

	protected List<Door> Doors;

	private bool Completed;

	private RichTextLabel RoomNameLabel;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{

		Completed = false;
		RoomNameLabel = GetNode<RichTextLabel>("RoomNameLabel");
		RoomNameLabel.Hide();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{


	}

	public List<Door> GetDoors() {
		return Doors;
	}

	public void DisplayRoomName() 
	{
		RoomNameLabel.Text = Name;
		RoomNameLabel.Show();
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
		}
	}
}
