using Godot;

public abstract partial class Carryable : Area2D
{
  private bool BeingCarried;

	private Character CarriedBy;

  private Character CharacterInArea;

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

  public Character GetCarriedBy() 
  {
    return CarriedBy;
  }

  public void SetCarriedBy(Character node = null) 
  {
    CarriedBy = node;
    CarriedBy.SetCarrying(this);
  }
  
  public override void _Process(double delta)
	{
		if (IsBeingCarried()) {
			// CharacterBody2D character = GetCarriedBy();
			// Node2D CarryPosition = character.GetNode<Node2D>("/root/Level/Character/CollisionShape2D/CarryCoordinates");
			Position = CarriedBy.Position;

      if (Input.IsActionJustPressed("pickup_putdown")) {
        SetBeingCarried(false);
      }
		}
    else if (CharacterInArea != null && Input.IsActionJustPressed("pickup_putdown")) {
      SetBeingCarried();
      SetCarriedBy(CharacterInArea);
      CharacterInArea = null;
    }
	}
  
  public virtual void _on_body_entered(Node2D node) 
  {

		if (node.IsInGroup("Player") && !BeingCarried) {
      CharacterInArea = (Character)node;
		}
	}

  public virtual void _on_body_exited(Node2D node)
  {
    if (node.IsInGroup("Player") && !BeingCarried) {
      CharacterInArea = null;
		}
  }
}