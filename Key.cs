using Godot;
using System;

public partial class Key : Carryable
{

	private Door UnlocksDoor;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		base._Ready();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		base._Process(delta);
	}

	// public override void _on_body_entered(Node2D node) {

	// 	if (node.IsInGroup("Player") && !IsBeingCarried()) {

	// 	}
	// }
}