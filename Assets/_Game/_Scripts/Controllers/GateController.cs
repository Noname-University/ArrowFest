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
        if (!gate.activateGate)
        {
            gate.gameObject.SetActive(false);
            return;
        }

        switch (gate.operationType)
        {
            case OperationType.Div:
                gate.text.text = "/";
                break;
            case OperationType.Mul:
                gate.text.text = "x";
                break;
            case OperationType.Sub:
                gate.text.text = "-";
                break;
            case OperationType.Sum:
                gate.text.text = "+";
                break;
        }

        switch (gate.colorType)
        {
            case ColorType.Blue:
                gate.gameObject.GetComponent<Material>().color = Color.blue;
                break;
            case ColorType.Red:
                gate.gameObject.GetComponent<Material>().color = Color.red;
                break;
        }

        gate.text.text = gate.value.ToString();
    }

    public void DoArrowOperation(Gate gate, int value)
    {
        switch (gate.operationType)
        {
            case OperationType.Div:
                value /= gate.value;
                break;
            case OperationType.Mul:
                value *= gate.value;
                break;
            case OperationType.Sub:
                value -= gate.value;
                break;
            case OperationType.Sum:
                value += gate.value;
                break;
        }

    }

    #endregion

    #region Callbacks

    #endregion
}