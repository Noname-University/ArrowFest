using UnityEngine;
using Utilities;

public class PlaneController : MonoSingleton<PlaneController>
{
	#region SerializedFields

	[SerializeField]
	private GameObject plane;

	[SerializeField]
	private float planeSideSize;

	[SerializeField]
	private float planeLength;

	#endregion

	#region Variables

	#endregion

	#region Props

	public float PlaneSideSize => planeSideSize;

	#endregion

	#region Unity Methods

	#endregion

	#region Methods

	#endregion

	#region Callbacks

	#endregion
}