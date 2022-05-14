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
        LeanTween.delayedCall(.5f,()=> transform.LeanMoveZ(transform.position.z+35f,5+movementEnemies.Length/10));
        for (int i = 0; i < movementEnemies.Length; i++)
        {
            int index = i;
            movementEnemies[index].GetComponent<Animator>().SetTrigger("TurnBack");
            movementEnemies[index].transform.LeanRotateY(0, .4f).setOnComplete
            (
                () =>
                {
                    movementEnemies[index].GetComponent<Animator>().SetTrigger("Run");
                    LeanTween.delayedCall(5+index/13f, ()=>
                        {
                            ArrowManager.Instance.DecreaseArrows(1);
                            movementEnemies[index].GetComponent<Animator>().SetTrigger("Die");
                            movementEnemies[index].transform.parent = transform.parent;
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