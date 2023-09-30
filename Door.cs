using Godot;
using System;

public partial class Door : Node2D
{

	private bool Open;

	private TileMap OpenTileMap;

	private TileMap ClosedTileMap;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Open = false;
		OpenTileMap = GetNode<TileMap>("OpenedTileMap");
		ClosedTileMap = GetNode<TileMap>("ClosedTileMap");
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
		}
		else {
			ClosedTileMap.Show();
			OpenTileMap.Hide();
		}
	}

	public bool isOpen() {
		return Open;
	}
}
