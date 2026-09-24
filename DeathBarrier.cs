using Godot;
using System;




public partial class DeathBarrier : Area2D
{
	public void ReloadLevel(Node2D node)
	{
		if (node is Player)
			GetTree().ReloadCurrentScene();
	}
}
