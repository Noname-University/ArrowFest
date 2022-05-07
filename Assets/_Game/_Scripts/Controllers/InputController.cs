using System;
using UnityEngine;
using Utilities;

public class InputController : MonoSingleton<InputController>
{
	#region SerializedFields

	#endregion

	#region Variables

	#endregion

	#region Props

	#endregion

	#region Actions

	public event Action<float> TouchPositionChanged;

	#endregion

	#region Unity Methods

	private void Update() 
	{
		if(Input.touchCount > 0)
		{
			var touch = Input.GetTouch(0);
			TouchPositionChanged?.Invoke(touch.deltaPosition.x);
		}
	}

	#endregion

	#region Methods

	#endregion

	#region Callbacks

	#endregion
}