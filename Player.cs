using Godot;
using System;

public partial class Player : CharacterBody2D
{
	public const float Speed = 300.0f;
	public const float JumpVelocity = -400.0f;
	
	[Export]
	public AnimatedSprite2D Sprite;
	
	[Export]
	public Timer Cooldown;
	




	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		// Add the gravity.
		if (!IsOnFloor())
		{
			velocity += GetGravity() * (float)delta;
		}

		// Handle Jump.
		if (Input.IsActionJustPressed("p1jump") && IsOnFloor())
		{
			velocity.Y = JumpVelocity;
		}

		// Get the input direction and handle the movement/deceleration.
		// As good practice, you should replace UI actions with custom gameplay actions.
		Vector2 direction = Input.GetVector("p1left", "p1right", "p1jump", "ui_down");
		if (direction != Vector2.Zero)
		{
			velocity.X = direction.X * Speed;
			
			if (Input.IsActionPressed("p1right")) 
			{
				Sprite.Play("Walk");
				Sprite.FlipH = false;
			}
			else if (Input.IsActionPressed("p1left")){
				Sprite.Play("Walk");
				Sprite.FlipH = true;
			}
			else if (Input.IsActionPressed("p1jump"))
			{
				Sprite.Play("Jump");
			}
			
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
			Sprite.Play("Idle");
			
		}

		Velocity = velocity;
		MoveAndSlide();
	}
}
