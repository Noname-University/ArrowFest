using System;
using UnityEngine;

public class PlayerFollower : MonoBehaviour
{
	#region SerializedFields

	[SerializeField]
	private Vector3 offset;

	#endregion

	#region Variables

	#endregion

	#region Props

	#endregion

	#region Unity Methods

	private void Start() 
	{
		GameManager.Instance.GameStatesChanged += OnGameStatesChanged; 
	}

    private void LateUpdate() 
	{
		if (GameManager.Instance.CurrentGameState == GameStates.InGame)
		{
			transform.position = PlayerController.Instance.transform.position + offset;
		}
	}

	#endregion

	#region Methods

	#endregion

	#region Callbacks

    private void OnGameStatesChanged(GameStates newState)
    {
        switch (newState)
		{
			case GameStates.Start:
				gameObject.SetActive(true);
				break;
			case GameStates.Final:
				gameObject.SetActive(false);
				break;
		}
    }

	#endregion
}