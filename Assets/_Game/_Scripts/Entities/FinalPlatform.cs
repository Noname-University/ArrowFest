using TMPro;
using UnityEngine;

public class FinalPlatform : MonoBehaviour, ICollectable
{
    #region SerializedFields

	[SerializeField]
	private int value;

	[SerializeField]
	private float scoreAmount;

	[SerializeField]
	private TextMeshPro scoreText;

    #endregion

    #region Variables

    #endregion

    #region Props

	public float ScoreAmount => scoreAmount;

    #endregion

    #region Unity Methods

	private void Start() 
	{
		scoreText.text = "X" + scoreAmount.ToString();
	}

    #endregion

    #region Methods

    #endregion

    #region Callbacks

    #endregion
    public void Collect()
    {
        ArrowManager.Instance.DecreaseArrows(value);
    }
}