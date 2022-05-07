using TMPro;
using UnityEngine;

public class GateController : MonoBehaviour
{
	#region SerializedFields

	[SerializeField]
	private Gate gate1;

	[SerializeField]
	private Gate gate2;

	#endregion

	#region Variables

	#endregion

	#region Props

	#endregion

	#region Unity Methods

	private void Start() 
	{
		InitGate(gate1);
		InitGate(gate2);
	}

	#endregion

	#region Methods

	private void InitGate(Gate gate)
	{
		if(!gate.activateGate)
		{
			gate.gameObject.SetActive(false);
			return;
		}
		
		switch (gate.operationType)
		{
			case OperationType.Div:
			break;
			case OperationType.Mul:
			break;
			case OperationType.Sub:
			break;
			case OperationType.Sum:
			break;
		}

		switch (gate.colorType)
		{
			case ColorType.Blue:
			break;
			case ColorType.Red:
			break;
		}

		gate.text.text = gate.value.ToString();
	}

	#endregion

	#region Callbacks

	#endregion
}