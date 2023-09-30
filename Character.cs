using Godot;
using System;

/**
 * Movement code by DevWorm
 * https://www.youtube.com/watch?v=KceMokK2qFA&ab_channel=DevWorm
 */
public partial class Character : CharacterBody2D
{

	[Export]
	private int maxSpeed = 200;

	[Export]
	private int acceleration = 500;

	[Export]
	private int friction = 1000;

	protected Vector2 input;


	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess(double delta)
	{
		Movement(delta);
	}

	protected Vector2 GetInput() {
		input.X = Convert.ToInt32(Input.IsActionPressed("move_right")) - Convert.ToInt32(Input.IsActionPressed("move_left"));
		input.Y = Convert.ToInt32(Input.IsActionPressed("move_down")) - Convert.ToInt32(Input.IsActionPressed("move_up"));
		return input.Normalized();
	}

	protected void Movement(double delta) {

		Vector2 input = GetInput();

		if (input == Vector2.Zero) {
			if (Velocity.Length() > (friction * delta)) {
				Velocity -= Velocity.Normalized() * (friction * (float)delta);
			}
			else {
				Velocity = Vector2.Zero;
			}
		}
		else {
			Velocity += (input * acceleration * (float)delta);
			Velocity = Velocity.LimitLength(maxSpeed);
			// Rotation = (float)((Math.Atan2(Velocity.Y, Velocity.X)) * (180/Math.PI));
			LookAt(Position + Velocity);
		}

		MoveAndSlide();
	}
}
