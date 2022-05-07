using TMPro;
using UnityEngine;

[System.Serializable]
public class Gate
{
	public bool activateGate;

	public int value;

	public OperationType operationType;

	public ColorType colorType;

	[Space(25)]
	
	public GameObject gameObject;

	public TextMeshPro text;
}