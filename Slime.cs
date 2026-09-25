using Godot;
using System;

public partial class Slime : CharacterBody2D
{
	[Export] private ShapeCast2D shapecastleft;
	[Export] private ShapeCast2D shapecastright;
	[Export] private AnimatedSprite2D Sprite;
	

	public override void _Ready()
	{
		//shapecastleft = GetNode<ShapeCast2D>("ShapeCastLeft");
		//shapecastright = GetNode<ShapeCast2D>("ShapeCastRight");
		
		

	}

	public const float Speed = 10.0f;
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




			var collisionsleft = shapecastleft.GetCollisionCount();

			for (var i = 0; i < collisionsleft; i++)
			{
				var collisionleft = shapecastleft.GetCollider(i);
				if (collisionleft is CharacterBody2D)
					velocity.X = -75.0f;
					Sprite.FlipH = true;
			}


			if (shapecastright.IsColliding()) ;
			{




				var collisionsright = shapecastright.GetCollisionCount();

				for (var i = 0; i < collisionsright; i++)
				{
					var collisionright = shapecastright.GetCollider(i);
					if (collisionright is CharacterBody2D)
						velocity.X = 75.0f;
						Sprite.Play("Walk");
						Sprite.FlipH = false;
						
				}



			}





			Velocity = velocity;
			MoveAndSlide();
		}
	}

	public void OnBodyEntered(Node2D body)
	{
		if (body is Player)
		{
			GetTree().ReloadCurrentScene();;
		}
	}
}
