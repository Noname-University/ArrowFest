using UnityEngine;
using Utilities;
using NaughtyAttributes;
using System;

public class LevelManager : MonoSingleton<LevelManager>
{
	#region SerializedFields

	[SerializeField, ReorderableList]
	private GameObject[] levels;

	#endregion

	#region Variables

	private GameObject currentLevel;

	#endregion

	#region Props

	#endregion

	#region Unity Methods

	private void Start() 
	{
		currentLevel = Instantiate(levels[SaveManager.Instance.CurrentLevel], Vector3.zero, Quaternion.identity, transform);
		currentLevel.SetActive(true);
	}

    #endregion

    #region Methods

    public void InitNextLevel()
	{
		Destroy(currentLevel);
		currentLevel = Instantiate(levels[SaveManager.Instance.CurrentLevel], Vector3.zero, Quaternion.identity, transform);
		currentLevel.SetActive(true);

		LeanTween.cancelAll();

		GameManager.Instance.UpdateGameState(GameStates.Start);
	}

	public void InitCurrentLevel()
	{
		LeanTween.cancelAll();
		Destroy(currentLevel);
		currentLevel = Instantiate(levels[SaveManager.Instance.CurrentLevel], Vector3.zero, Quaternion.identity, transform);
		GameManager.Instance.UpdateGameState(GameStates.Start);
	}

    #endregion

    #region Callbacks

    #endregion
}