using Godot;
using System;
using System.Collections.Generic;

public partial class Key : Carryable
{
	[Export]
	private Door[] UnlockDoors;

	// private Door[] UnlockDoors;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		base._Ready();
		// UnlockDoors = new List<Door>();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		base._Process(delta);
	}

	public void UnlockDoor(Door door) {

		if (CheckKeyUnlocksDoor(door)) {
			door.SetOpen();
		}
	}

	public bool CheckKeyUnlocksDoor(Door door) {
		foreach (Door _door in UnlockDoors) {
			if (_door == door) {
				return true;
			}
		}
		return false; 
	}
}
