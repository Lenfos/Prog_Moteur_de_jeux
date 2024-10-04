using Godot;

[GlobalClass]
public partial class Manager : SceneTree 
{
	private static Manager instance;

	public static Manager Get()
	{
		return instance;
	}

	public override void _Initialize()
	{
		if (instance == null)
		{
			instance = this;
		}
	}

	public LevelManager GetLevelManager(){
		return LevelManager.Get();
	}
	
	public SaveManager GetSaveManager(){
		return SaveManager.Get();
	}
}
