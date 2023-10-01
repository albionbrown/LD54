using Godot;
using System;

public partial class LevelEndArea : Node2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void _on_level_end_area_body_entered(Node2D node)
	{
		if (node.IsInGroup("Player")) {
			SceneTree sceneTree = GetTree();
			Window root = sceneTree.Root;
			Level level = (Level)root.GetChild(0);
			int nextLevel = level.GetLevelNumber()+1;

			sceneTree.ChangeSceneToFile($"res://Level{nextLevel}.tscn");
		}
	}
}
