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

	private void LateUpdate() 
	{
		if (GameManager.Instance.CurrentGameState == GameStates.InGame)
		{
			transform.position = PlayerController.Instance.transform.position + offset;
		}
		else if (GameManager.Instance.CurrentGameState == GameStates.Final)
		{
			gameObject.SetActive(false);
		}
	}

	#endregion

	#region Methods

	#endregion

	#region Callbacks

	#endregion
}