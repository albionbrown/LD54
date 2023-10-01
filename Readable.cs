using Godot;

public abstract partial class Readable : Node2D
{

  [Export]
	protected RichTextLabel Content; 

	protected bool PlayerNear;

  // Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		PlayerNear = false;
		Content.Hide();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (PlayerNear) {
			if (Input.IsActionJustPressed("space")) {
				Content.Show();
			}
		}
		else {
			Content.Hide();
		}
	}

  public void _on_readable_area_body_entered(Node2D node) 
	{
		PlayerNear = true;
	}

	public void _on_readable_area_body_exited(Node2D node)
	{
		PlayerNear = false;
	}
}