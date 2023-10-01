using Godot;
using System;

public partial class Door : Node2D
{

	[Export]
	private bool Open;

	[Export]
	private Door[] FurtherOpens;

	private TileMap OpenTileMap;

	private TileMap ClosedTileMap;

	private StaticBody2D DoorBody;

	private uint DefaultCollisionLayer;
	private uint DefaultCollisionMask;
	
	private Character PlayerNear;

	private RichTextLabel Label;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Open = false;

		OpenTileMap = GetNode<TileMap>("OpenedTileMap");
		ClosedTileMap = GetNode<TileMap>("ClosedTileMap");
		DoorBody = GetNode<StaticBody2D>("StaticBody2D");

		DefaultCollisionLayer = 1;
		DefaultCollisionMask = 1;

		Label = GetNode<RichTextLabel>("RichTextLabel");
		Label.Hide();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{

		if (PlayerNear != null) {

			Node2D playerCarrying = PlayerNear.GetCarrying();
			if (!Open
			&& playerCarrying != null 
			&& playerCarrying.IsInGroup("Keys")) {
				Label.Show();
			}

			if (Input.IsActionJustPressed("space") 
			&& playerCarrying != null 
			&& playerCarrying.IsInGroup("Keys")) {

				Key key = (Key)playerCarrying;
				if (key.CheckKeyUnlocksDoor(this)) {
					key.UnlockDoor(this);
					key.QueueFree();
					PlayerNear.SetCarrying(null);
					playerCarrying = null;
				}
			}
		}
		else {
			Label.Hide();
		}
	}

	public void SetOpen(bool open = true)
	{
		Open = open;
		if (Open) {
			ClosedTileMap.Hide();
			OpenTileMap.Show();
			DoorBody.CollisionLayer = 0;
			DoorBody.CollisionMask = 0;

			// Open other doors if configured
			foreach (Door _door in FurtherOpens) {
				_door.SetOpen();
			}
		}
		else {
			ClosedTileMap.Show();
			OpenTileMap.Hide();
			DoorBody.CollisionLayer = DefaultCollisionLayer;
			DoorBody.CollisionMask = DefaultCollisionMask;
		}
	}

	public bool isOpen()
	{
		return Open;
	}

	public void _on_body_entered(Node2D node)
	{
		if (node.IsInGroup("Player")) {
			PlayerNear = (Character)node;
		}
	}

	public void _on_body_exited(Node2D node)
	{
		if (node.IsInGroup("Player")) {
			PlayerNear = null;
		}
	}
}
