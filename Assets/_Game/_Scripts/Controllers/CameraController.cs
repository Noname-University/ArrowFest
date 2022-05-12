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
		GameManager.Instance.GameStatesChanged += OnGameStatesChanged;
		mainCamera = Camera.main.transform;
		player = PlayerController.Instance.transform;
		//mainCamera.transform.position = player.transform.position + offset;
	}

	private void Update()
	{
		transform.position += new Vector3(0, 0, PlayerController.Instance.CurrentSpeed * Time.deltaTime * PlayerController.Instance.CurrentFinalScoreAmount);	
	}

	private void LateUpdate() 
	{
		// mainCamera.transform.position = player.transform.position + offset;
	}

	#endregion

	#region Methods

	#endregion

	#region Callbacks

	 private void OnGameStatesChanged(GameStates newState)
	 {
		 if(newState == GameStates.Final)
		 {
			mainCamera.transform.position = player.transform.position + offset;
		 }
	 }

	#endregion
}