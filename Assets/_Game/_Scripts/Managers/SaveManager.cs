using UnityEngine;
using Utilities;

public class SaveManager : MonoSingleton<SaveManager>
{
	#region SerializedFields

	#endregion

	#region Variables

	private int currentLevel;

	#endregion

	#region Props

	public int CurrentLevel => currentLevel;

	#endregion

	#region Unity Methods

	private void Awake() 
	{
		currentLevel = PlayerPrefs.GetInt("Level");
	}
	
	private void Start() 
	{
		GameManager.Instance.GameStatesChanged += OnGameStatesChanged; 
	}

	#endregion

	#region Methods

	#endregion

	#region Callbacks
	
    private void OnGameStatesChanged(GameStates newState)
    {
        if(newState == GameStates.Success)
		{
			currentLevel++;
			PlayerPrefs.SetInt("Level", currentLevel);
		}
    }

	#endregion
}