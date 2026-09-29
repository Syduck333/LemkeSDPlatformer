using Godot;
using System;

public partial class Rat : CharacterBody2D
{
    [Export] private ShapeCast2D shapecastleftr;
    [Export] private ShapeCast2D shapecastrightr;
    [Export] private AnimatedSprite2D Spriter;
	

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


		


        if (shapecastleftr.IsColliding()) ;
        {




            var collisionsleft = shapecastleftr.GetCollisionCount();

            for (var i = 0; i < collisionsleft; i++)
            {
                var collisionleft = shapecastleftr.GetCollider(i);
                if (collisionleft is CharacterBody2D)
                    velocity.X = -105.0f;
                Spriter.FlipH = true;
            }


            if (shapecastrightr.IsColliding()) ;
            {




                var collisionsright = shapecastrightr.GetCollisionCount();

                for (var i = 0; i < collisionsright; i++)
                {
                    var collisionright = shapecastrightr.GetCollider(i);
                    if (collisionright is CharacterBody2D)
                        velocity.X = 105.0f;
                    Spriter.Play("Walk");
                    Spriter.FlipH = false;
						
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
            GetTree().CallDeferred("reload_current_scene");
        }
    }
}