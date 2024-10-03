using Godot;

[GlobalClass]
public partial class Manager : SceneTree 
{
	private static Manager instance;
	
	public static Manager Get(){
		if (instance == null){
			instance = new Manager();
		}
		return instance;
	}
	
	public LevelManager GetLevelManager(){
		return LevelManager.Get();
	}
	
	public SaveManager GetSaveManager(){
		return SaveManager.Get();
	}
}
