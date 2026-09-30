using Godot;
using System;


public partial class Exit : Area2D
{
    public void ReloadLevel(Node2D node)
    {
        if (node is Player)
            GetTree().ChangeSceneToFile("res://menu.tscn");
    }
}