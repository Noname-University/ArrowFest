using UnityEngine;

public class MovementEnemy : MonoBehaviour, ICollectable
{
    #region SerializedFields
    [SerializeField]
    private int score;
    [SerializeField]
    private int value;
    [SerializeField]
    private GameObject[] movementEnemies;

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
        for (int i = 0; i < movementEnemies.Length; i++)
        {
            int index = i;
            movementEnemies[i].GetComponent<Animator>().SetTrigger("TurnBack");
            movementEnemies[i].transform.LeanRotateY(0, .5f).setOnComplete
            (
                () =>
                {
                    movementEnemies[index].GetComponent<Animator>().SetTrigger("Run");
                    movementEnemies[index].transform.LeanMoveLocalZ(1f + index, 1f + index).setOnComplete
                    (
                        () =>
                        {
                            movementEnemies[index].GetComponent<Animator>().SetTrigger("Die");
                            LeanTween.delayedCall(3f, () => movementEnemies[index].SetActive(false));
                        }
                    );

                }
            );



        }


    }


    #endregion

    #region Callbacks

    #endregion
}