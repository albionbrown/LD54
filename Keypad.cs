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

	[Export]
	private String UnlockCode;

	private Room Room;

	private Color DefaultColour;

	private bool PlayerNear;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Room = GetParent<Room>();

		ColorRect colorRect = GetNode<ColorRect>("ColorRect");
		DefaultColour = new Color("252525");
		colorRect.Color = DefaultColour;

		PlayerNear = false;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (PlayerNear && Input.IsActionPressed("space")) {
			// @todo show form
			KeypadForm.Toggle();
			Correct();
		}

		// if (KeypadForm.GetCorrect()) {
			// Correct();
		// }
	}

	public void _on_body_entered(Node2D node) {

		if (node.IsInGroup("Player")) {
			ColorRect colorRect = GetNode<ColorRect>("ColorRect");
			colorRect.Color = new Color("d51d1f");
			PlayerNear = true;
		}
	}

	public void Correct() {

		foreach (Door door in UnlocksDoors) {
			door.SetOpen();
		}
	}

	public void _on_body_exited(Node2D node) {

		if (node.IsInGroup("Player")) {
			ColorRect colorRect = GetNode<ColorRect>("ColorRect");
			colorRect.Color = DefaultColour;
			PlayerNear = false;
		}
	}
}
