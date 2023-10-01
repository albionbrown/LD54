using Godot;
using System;

public partial class KeypadForm : Node2D
{

	private bool Correct;

	private bool Showing;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{	
		Hide();
		Showing = false;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void SetCorrect(bool correct = true)
	{
		Correct = correct;
	}

	public bool GetCorrect()
	{
		return Correct;
	}

	public void SetShowing(bool showing = true)
	{
		Showing = showing;
	}

	public bool GetShowing()
	{
		return Showing;
	}

	public void Toggle() 
	{
		Showing = !Showing;
		if (Showing) {
			Show();
		}
		else {
			Hide();
		}
	}	
}
