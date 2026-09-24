using Godot;
using System;


public partial class Level2Teleport : Area2D
{
    public void ReloadLevel(Node2D node)
    {
        if (node is Player)
            GetTree().ChangeSceneToFile("res://level_2.tscn");
    }
}
