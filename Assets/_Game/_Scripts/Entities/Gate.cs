using TMPro;
using UnityEngine;

[System.Serializable]
public class Gate : MonoBehaviour, ICollectable
{
	[SerializeField]
	private GateController gateController;

	public bool activateGate;

	public int value;

	public OperationType operationType;

	public ColorType colorType;

	[Space(25)]

	public TextMeshPro text;

	private void Start() 
	{
		InitGate();
	}

	private void InitGate()
    {
        if (!activateGate)
        {
            gameObject.SetActive(false);
            return;
        }

        switch (operationType)
        {
            case OperationType.Div:
                text.text = "/";
                break;
            case OperationType.Mul:
                text.text = "x";
                break;
            case OperationType.Sub:
                text.text = "-";
                break;
            case OperationType.Sum:
                text.text = "+";
                break;
        }

        var renderer = gameObject.GetComponent<Renderer>();
        switch (colorType)
        {
            case ColorType.Blue:
                renderer.material = gateController.Blue;
                break;
            case ColorType.Red:
                renderer.material = gateController.Red;
                break;
        }

        text.text = text.text + value.ToString();
    }

	public void DoArrowOperation()
    {
        switch (operationType)
        {
            case OperationType.Div:
                ArrowManager.Instance.SetArrows(ArrowManager.Instance.CurrentArrowCount / value);
                break;
            case OperationType.Mul:
                ArrowManager.Instance.SetArrows(ArrowManager.Instance.CurrentArrowCount * value);
                break;
            case OperationType.Sub:
					ArrowManager.Instance.DecreaseArrows(value);
                break;
            case OperationType.Sum:
                ArrowManager.Instance.IncreaseArrows(value);
                break;
        }
    }

	public void Collect()
    {
		DoArrowOperation();
        Close();
    }

    private void Close()
    {
        gateController.CloseGates();
    }
}