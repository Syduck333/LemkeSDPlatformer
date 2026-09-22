using Godot;
using System;

public partial class Slime : CharacterBody2D
{
	[Export]
	private ShapeCast2D shapecastleft;
	[Export]
	private ShapeCast2D shapecastright;

	public override void _Ready()
	{
		//shapecastleft = GetNode<ShapeCast2D>("ShapeCastLeft");
		//shapecastright = GetNode<ShapeCast2D>("ShapeCastRight");


	}

	public const float Speed = 300.0f;
	public const float JumpVelocity = -400.0f;

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;


		if (!IsOnFloor())
		{
			velocity += GetGravity() * (float)delta;
		}


		if (shapecastleft.IsColliding()) ;
		{
			
			
			
			
			var collisions = shapecastleft.GetCollisionCount();

			for (var i = 0; i < collisions; i++)
			{
				var collision = shapecastleft.GetCollider(i);
				if (collision is CharacterBody2D)
					velocity.X = -200.0f;
			}
		}


		// Handle Jump.
		if (Input.IsActionJustPressed("ui_accept") && IsOnFloor())
		{
			velocity.Y = JumpVelocity;
		}

		// Get the input direction and handle the movement/deceleration.
		// As good practice, you should replace UI actions with custom gameplay actions.
		Vector2 direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
		if (direction != Vector2.Zero)
		{
			velocity.X = direction.X * Speed;
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
		}

		Velocity = velocity;
		MoveAndSlide();
	}
}
