using Godot;

public partial class menu : Node2D
{
	// The name must match exactly what you input in the Node connection window
	private void _on_button_pressed()
	{
		GetTree().ChangeSceneToFile("res://Scenes/level.tscn");
	}
}
