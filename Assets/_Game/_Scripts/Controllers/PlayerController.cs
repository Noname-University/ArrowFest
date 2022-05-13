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
    private float currentSpeed;
    private Vector3 desiredScale;
    public float CurrentFinalScoreAmount => currentFinalScoreAmount;
    private float currentFinalScoreAmount = 1;

    #endregion

    #region Props
    public float CurrentSpeed => currentSpeed;

    public float Speed => speed;

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
        transform.position += new Vector3(0, 0, currentSpeed * Time.deltaTime * currentFinalScoreAmount);
    }

    private void OnTriggerEnter(Collider other)
    {
        var collectable = other.GetComponent<ICollectable>();
        if (collectable != null)
        {
            collectable.Collect();
            ArrowCountChanged?.Invoke();
            if (GameManager.Instance.CurrentGameState != GameStates.Final) return;
            ArrowManager.Instance.SetFinalArrowPositions();
        }

        var finishLine = other.GetComponent<FinishLine>();
        if (finishLine != null)
        {
            GameManager.Instance.UpdateGameState(GameStates.Final);
        }

        var finalPlatform = other.GetComponent<FinalPlatform>();
        if (finalPlatform != null)
        {
            collectable.Collect();
            currentFinalScoreAmount = finalPlatform.ScoreAmount;
        }
    }

    #endregion

    #region Methods

    #endregion

    #region Callbacks

    private void OnGameStatesChanged(GameStates newState)
    {
        if (newState == GameStates.InGame)
        {
            currentSpeed = speed;
        }
        if (newState == GameStates.Fail)
        {
            transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
            currentSpeed = 0;
        }
        if (newState == GameStates.Success)
        {
            ScoreController.Instance.IncreaseScore(currentFinalScoreAmount);
            currentSpeed = 0;
        }
    }
    private void OnTouchPositionChanged(Touch touch)
    {
        if (GameManager.Instance.CurrentGameState == GameStates.InGame)
        {
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