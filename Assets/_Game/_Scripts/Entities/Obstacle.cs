using UnityEngine;

public class Obstacle : MonoBehaviour, ICollectable
{
    #region SerializedFields

    [SerializeField]
    private int value;

    [SerializeField]
    private int score;

    #endregion

    #region Variables

    #endregion

    #region Props

    #endregion

    #region Unity Methods

    #endregion

    #region Methods

    public void Collect()
    {
        ArrowManager.Instance.DecreaseArrows(value);
        ScoreController.Instance.IncreaseScore(score);
        gameObject.GetComponent<Animator>().SetTrigger("OnDead");
        LeanTween.delayedCall(3f, () => Close());
    }

    private void Close()
    {
        gameObject.SetActive(false);

    }

    #endregion

    #region Callbacks

    #endregion
}