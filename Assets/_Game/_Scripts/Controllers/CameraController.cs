using System;
using UnityEngine;
using Utilities;

public class CameraController : MonoSingleton<CameraController>
{
	#region SerializedFields

	#endregion

	#region Variables

	private Vector3 offset;
	private Transform mainCamera;
	private Transform player;


	#endregion

	#region Props

	#endregion

	#region Unity Methods

	private void Start() 
	{
		player = PlayerController.Instance.transform;
		offset = transform.position - player.position;
		GameManager.Instance.GameStatesChanged += OnGameStateChanged;
	}

    private void LateUpdate() 
	{
		transform.position = new Vector3(0, player.position.y + offset.y, player.position.z + offset.z);
	}

	#endregion

	#region Methods

	#endregion

	#region Callbacks

    private void OnGameStateChanged(GameStates newState)
    {
		if (newState == GameStates.Start)
		{
			offset = transform.position - player.position;
		}
    }

	#endregion
}