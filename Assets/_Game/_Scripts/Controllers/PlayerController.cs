using System;
using UnityEngine;
using Utilities;

public class PlayerController : MonoSingleton<PlayerController>
{
    #region SerializedFields

    [SerializeField]
    private float speed;

    [SerializeField]
    private float sideSpeed;

    #endregion

    #region Variables
    private bool canMove = false;

    #endregion

    #region Props

    #endregion
    public event Action ArrowCountChanged;

    #region Unity Methods

    private void Start()
    {
        InputController.Instance.TouchPositionChanged += OnTouchPositionChanged;
    }

    private void Update()
    {
        if (canMove == true)
        {
            transform.position += new Vector3(0, 0, speed * Time.deltaTime);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        var collectable = other.GetComponent<ICollectable>();
        if (collectable != null)
        {
            collectable.Collect();
            ArrowCountChanged?.Invoke();
            return;
        }
        if (other.tag == "Finish")
        {
            GameManager.Instance.UpdateGameState(GameStates.Final);
        }
    }

    #endregion

    #region Methods

    #endregion

    #region Callbacks

    private void OnTouchPositionChanged(Touch touch)
    {
        if (GameManager.Instance.CurrentGameState == GameStates.InGame)
        {
            canMove = true;
            transform.position = new Vector3
            (
                Mathf.Clamp
                (
                    transform.position.x + sideSpeed * Time.deltaTime * touch.deltaPosition.x,
                    -1,
                    1
                ),
                transform.position.y,
                transform.position.z
            );
        }
        else if (GameManager.Instance.CurrentGameState == GameStates.Final)
        {
            canMove = true;
            transform.position = new Vector3(0, 0, transform.position.z);
        }
    }

    #endregion
}