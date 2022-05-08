using TMPro;
using UnityEngine;

public class GateController : MonoBehaviour
{
    #region SerializedFields

    [SerializeField]
    private Material red;
    
    [SerializeField]
    private Material blue;

    [SerializeField]
    private Gate gate1;

    [SerializeField]
    private Gate gate2;

    #endregion

    #region Variables

    #endregion

    #region Props

    public Material Red => red;

    public Material Blue => blue;

    #endregion

    #region Unity Methods

    #endregion

    #region Methods

    public void CloseGates()
    {
        gate1.gameObject.SetActive(false);
        gate2.gameObject.SetActive(false);
    }

    #endregion

    #region Callbacks

    #endregion
}