using UnityEngine;
using Utilities;
using UnityEngine.SceneManagement;
using TMPro;
using System;
using UnityEngine.UI;

public class UIController : MonoSingleton<UIController>
{
    #region SerializedFields

    [SerializeField]
    private TextMeshProUGUI scoreText;

    [SerializeField]
    private TextMeshProUGUI levelText;
    [SerializeField]
    private TextMeshProUGUI buttonScoreText;

    [SerializeField]
    private GameObject holdAndMovePanel;

    [SerializeField]
    private GameObject successPanel;

    [SerializeField]
    private GameObject failPanel;

    [SerializeField]
    private TextMeshPro arrowCountText;

    // [SerializeField]
    // private GameObject slideAndMovePanel;

    #endregion

    #region Variables

    #endregion

    #region Props

    #endregion

    #region Unity Methods

    private void Start()
    {
        GameManager.Instance.GameStatesChanged += OnGameStatesChanged;
        ScoreController.Instance.ScoreChange += OnScoreChange;
    }


    #endregion

    #region Methods
    private void InitGame()
    {
        InputController.Instance.TouchPositionChanged += OnTouchPositionChanged;
        PlayerController.Instance.ArrowCountChanged += OnArrowCountChanged;

        successPanel.SetActive(false);
        failPanel.SetActive(false);
        holdAndMovePanel.transform.parent.gameObject.SetActive(true);
        holdAndMovePanel.transform.LeanMoveLocalX(-250f, 0.5f).setOnComplete(()=> holdAndMovePanel.transform.LeanMoveLocalX(250f, 0.5f).setLoopPingPong());
        arrowCountText.gameObject.SetActive(true);
        arrowCountText.text = "1";

        GetCurrentLevel();
        GetCurrentScore();
    }
    private void GetCurrentLevel()
    {
        levelText.text = "Level " + (SceneManager.GetActiveScene().buildIndex + 1).ToString();
    }

    private void GetCurrentScore()
    {
        scoreText.text = ScoreController.Instance.CurrentScore.ToString();
    }

    private void GetCurrentArrowCount()
    {
        arrowCountText.text = ArrowManager.Instance.CurrentArrowCount.ToString();
    }

    #endregion

    #region Callbacks
    private void OnTouchPositionChanged(Touch touch)
    {
        if(touch.phase != TouchPhase.Began) return;
        holdAndMovePanel.transform.parent.gameObject.SetActive(false);
        arrowCountText.gameObject.SetActive(true);
        InputController.Instance.TouchPositionChanged -= OnTouchPositionChanged;
        GameManager.Instance.UpdateGameState(GameStates.InGame);

    }

    private void OnArrowCountChanged()
    {
        GetCurrentArrowCount();

    }

    private void OnGameStatesChanged(GameStates newState)
    {
        switch (newState)
        {
            case GameStates.Start:
                InitGame();
                break;
            case GameStates.InGame:
                break;
            case GameStates.Fail:
                failPanel.SetActive(true);
                break;
            case GameStates.Final:
                PlayerController.Instance.ArrowCountChanged -= OnArrowCountChanged;
                arrowCountText.gameObject.SetActive(false);
                break;
            case GameStates.Success:
                successPanel.SetActive(true);
                buttonScoreText.text = scoreText.text;
                break;
        }
    }

    private void OnScoreChange()
    {
        GetCurrentScore();
    }


    #endregion
}