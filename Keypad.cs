using Godot;
using System;
using System.Security.Cryptography.X509Certificates;

public partial class Keypad : Node2D
{

	[Signal]
	public delegate void DoorUnlockEventHandler(Door door);

	[Export]
	private KeypadForm KeypadForm;

	[Export]
	private Door[] UnlocksDoors;

	private Color DefaultColour;

	private bool PlayerNear;

	private bool Solved;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{

		ColorRect colorRect = GetNode<ColorRect>("ColorRect");
		DefaultColour = new Color("252525");
		colorRect.Color = DefaultColour;

		PlayerNear = false;
		Solved = false;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (PlayerNear && Input.IsActionJustPressed("space")) {

			KeypadForm.Toggle();
		}

		// Only open the doors once
		if (Solved ^ (Solved = KeypadForm.GetCorrect())) {
			OpenAllDoors();
		}
	}

	public void _on_body_entered(Node2D node) {

		if (node.IsInGroup("Player")) {
			ColorRect colorRect = GetNode<ColorRect>("ColorRect");
			colorRect.Color = new Color("d51d1f");
			PlayerNear = true;
		}
	}

	public void _on_body_exited(Node2D node) {

		if (node.IsInGroup("Player")) {
			ColorRect colorRect = GetNode<ColorRect>("ColorRect");
			colorRect.Color = DefaultColour;
			PlayerNear = false;
		}
	}

	public void OpenAllDoors() {
		foreach (Door door in UnlocksDoors) {
			door.SetOpen();
		}
	}
}
