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
    private Vector3 desiredScale;

    #endregion

    #region Props

    #endregion
    public event Action ArrowCountChanged;

    #region Unity Methods

    private void Start()
    {
        InputController.Instance.TouchPositionChanged += OnTouchPositionChanged;
        GameManager.Instance.GameStatesChanged += OnGameStatesChanged;
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

    private void OnGameStatesChanged(GameStates newState)
    {
        if (newState == GameStates.Fail)
        {
            transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
        }
    }
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
                    -1.4f,
                    1.4f
                ),
                transform.position.y,
                transform.position.z
            );

            transform.localScale = new Vector3(1 - Mathf.Abs(transform.position.x) / 6, transform.localScale.y, transform.localScale.z);
        }
        else if (GameManager.Instance.CurrentGameState == GameStates.Final)
        {
            canMove = true;
            transform.position = new Vector3(0, 0, transform.position.z);
            transform.localScale = new Vector3
            (
                Mathf.Clamp
                (
                    transform.localScale.x + Time.deltaTime * touch.deltaPosition.x,
                    transform.localScale.x,
                    1.4f
                ),
                transform.localScale.y,
                transform.localScale.z
               );
        }
    }

    #endregion
}