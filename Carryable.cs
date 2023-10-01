using Godot;

public abstract partial class Carryable : Area2D
{
  private bool BeingCarried;

	private CharacterBody2D CarriedBy;

  private CharacterBody2D CharacterInArea;

  public override void _Ready()
	{
    CharacterInArea = null;
		SetBeingCarried(false);
	}

  public bool IsBeingCarried()
  {
    return BeingCarried;
  }

  public void SetBeingCarried(bool beingCarried = true)
  {
    BeingCarried = beingCarried;
  }

  public CharacterBody2D GetCarriedBy() 
  {
    return CarriedBy;
  }

  public void SetCarriedBy(CharacterBody2D node = null) 
  {
    CarriedBy = node;
  }
  
  public override void _Process(double delta)
	{
		if (IsBeingCarried()) {
			// CharacterBody2D character = GetCarriedBy();
			// Node2D CarryPosition = character.GetNode<Node2D>("/root/Level/Character/CollisionShape2D/CarryCoordinates");
			Position = CarriedBy.Position;

      if (Input.IsActionJustPressed("space")) {
        SetBeingCarried(false);
      }
		}
    else if (CharacterInArea != null && Input.IsActionJustPressed("space")) {
      SetBeingCarried();
      SetCarriedBy(CharacterInArea);
      CharacterInArea = null;
    }
	}
  
  public virtual void _on_body_entered(Node2D node) 
  {

		if (node.IsInGroup("Player") && !BeingCarried) {
      CharacterInArea = (CharacterBody2D)node;
		}
	}

  public virtual void _on_body_exited(Node2D node)
  {
    if (node.IsInGroup("Player") && !BeingCarried) {
      CharacterInArea = null;
		}
  }
}