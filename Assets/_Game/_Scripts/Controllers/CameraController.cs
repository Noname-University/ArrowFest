using UnityEngine;
using Utilities;

public class CameraController : MonoSingleton<CameraController>
{
	#region SerializedFields

	[SerializeField]
	private Vector3 offset;

	#endregion

	#region Variables

	private Transform mainCamera;
	private Transform player;


	#endregion

	#region Props

	#endregion

	#region Unity Methods

	private void Start() 
	{
		mainCamera = Camera.main.transform;
		player = PlayerController.Instance.transform;
	}

	private void LateUpdate() 
	{
		mainCamera.transform.position = player.transform.position + offset;
	}

	#endregion

	#region Methods

	#endregion

	#region Callbacks

	#endregion
}