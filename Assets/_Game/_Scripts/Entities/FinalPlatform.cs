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

    [SerializeField]
    private GameObject[] Enemies;

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
        Debug.Log("asd");
        ArrowManager.Instance.DecreaseArrows(value);
        for (int i = 0; i < Enemies.Length; i++)
        {
            Enemies[i].GetComponent<Animator>().SetTrigger("OnDead");
            // LeanTween.delayedCall(10f, () =>
            // {
            //     Enemies[i].SetActive(false);

            // });
        }
    }
}