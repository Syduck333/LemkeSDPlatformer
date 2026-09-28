using Godot;

public partial class Button : Control
{
	[Export] public string SceneName;
	private void OnButtonPressed()
	{
		GetTree().ChangeSceneToFile(SceneName);
	}
}
