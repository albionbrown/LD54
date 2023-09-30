using Godot;
using System;

public partial class Door : Node2D
{

	[Export]
	private bool Open;

	private TileMap OpenTileMap;

	private TileMap ClosedTileMap;

	private StaticBody2D DoorBody;

	private uint DefaultCollisionLayer;
	private uint DefaultCollisionMask;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Open = false;

		OpenTileMap = GetNode<TileMap>("OpenedTileMap");
		ClosedTileMap = GetNode<TileMap>("ClosedTileMap");
		DoorBody = GetNode<StaticBody2D>("StaticBody2D");

		DefaultCollisionLayer = 1;
		DefaultCollisionMask = 1;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void SetOpen(bool open = true) {
		Open = open;
		if (Open) {
			ClosedTileMap.Hide();
			OpenTileMap.Show();
			DoorBody.CollisionLayer = 0;
			DoorBody.CollisionMask = 0;
		}
		else {
			ClosedTileMap.Show();
			OpenTileMap.Hide();
			DoorBody.CollisionLayer = DefaultCollisionLayer;
			DoorBody.CollisionMask = DefaultCollisionMask;
		}
	}

	public bool isOpen() {
		return Open;
	}
}
