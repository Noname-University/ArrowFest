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

	public event Action<Touch> TouchPositionChanged;

	#endregion

	#region Unity Methods

	private void Update() 
	{
		if(Input.touchCount > 0)
		{
			var touch = Input.GetTouch(0);
			TouchPositionChanged?.Invoke(touch);
		}
	}

	#endregion

	#region Methods

	#endregion

	#region Callbacks

	#endregion
}