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
    private float currentFinalScoreAmount = 1;

    #endregion

    #region Props
    public float CurrentSpeed => currentSpeed * Time.deltaTime * currentFinalScoreAmount;

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
            LeanTween.delayedCall(.01f,()=> ArrowManager.Instance.SetFinalArrowPositions());
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
        switch (newState)
        {
            case GameStates.Start:
                InputController.Instance.TouchPositionChanged += OnTouchPositionChanged;
                currentSpeed = 0;
                transform.localScale =Vector3.one;
                currentFinalScoreAmount = 1;
                transform.position = Vector3.zero;
                break;
            case GameStates.InGame:
                currentSpeed = speed;
                break;
            case GameStates.Final:
                InputController.Instance.TouchPositionChanged -= OnTouchPositionChanged;
                break;
            case GameStates.Fail:
                currentSpeed = 0;
                break;
            case GameStates.Success:
                ScoreController.Instance.IncreaseScore(currentFinalScoreAmount);
                currentSpeed = 0;
                break;
        }
    }
    
    private void OnTouchPositionChanged(Touch touch)
    {
        if (GameManager.Instance.CurrentGameState != GameStates.InGame) return;
        
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

    #endregion
}