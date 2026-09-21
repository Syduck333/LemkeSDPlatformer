using Godot;
using System;

public partial class Slime : RigidBody2D
{
	
	public override void _Ready()
	{
		var animatedSprite2D = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		animatedSprite2D.Animation = "Idle";
		animatedSprite2D.Play("Idle");
	}

	
	public override void _Process(double delta)
	{
		
	}


	public override void _PhysicsProcess(double delta)
	{
		
	}
}
