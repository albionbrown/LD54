using Godot;
using System;

public partial class Form : Node2D
{

	[Export]
	private String UnlockCode;

	private bool Correct;

	private bool Showing;

	private TextEdit InputBox;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{	
		Hide();
		Showing = false;
		Correct = false;
		InputBox = GetNode<TextEdit>("AnswerInput");
		InputBox.FocusMode = Control.FocusModeEnum.Click;
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

	public void _on_check_button_pressed() {
		if (InputBox.Text == UnlockCode) {
			Correct = true;
		}
	}
}
