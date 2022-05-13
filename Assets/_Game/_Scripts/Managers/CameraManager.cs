using UnityEngine;
using Utilities;
using Cinemachine;
using System;

public class CameraManager : MonoSingleton<CameraManager>
{
	#region SerializedFields

	[SerializeField]
	private CinemachineVirtualCamera inGameCam;

	[SerializeField]
	private CinemachineVirtualCamera finalCam;

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

    #endregion

    #region Methods

    #endregion

    #region Callbacks

    private void OnGameStatesChanged(GameStates newState)
    {
        switch (newState)
		{
			case GameStates.Start:
				inGameCam.Priority = 10;
				finalCam.Priority = 0;
				break;
			case GameStates.Final:
				inGameCam.Priority = 0;
				finalCam.Priority = 10;
				break;
		}
    }

    #endregion
}