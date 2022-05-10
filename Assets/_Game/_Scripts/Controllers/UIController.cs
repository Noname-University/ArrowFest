using UnityEngine;
using Utilities;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class UIController : MonoSingleton<UIController>
{
    #region SerializedFields

    [SerializeField]
    private TextMeshProUGUI scoreText;

    [SerializeField]
    private TextMeshProUGUI levelText;

    [SerializeField]
    private GameObject holdAndMovePanel;

    [SerializeField]
    private GameObject successPanel;

    [SerializeField]
    private GameObject failPanel;

    [SerializeField]
    private TextMeshPro arrowCountText;

    [SerializeField]
    private GameObject slideAndMovePanel;

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
        holdAndMovePanel.SetActive(true);
        arrowCountText.gameObject.SetActive(true);
        arrowCountText.text = "1";

        GetCurrentLevel();
        GetCurrentScore();
    }
    private void GetCurrentLevel()
    {
        levelText.text = "Level " + " " + (SceneManager.GetActiveScene().buildIndex + 1).ToString();
    }

    private void GetCurrentScore()
    {
        scoreText.text = ScoreController.Instance.CurrentScore.ToString();
    }

    public void GetNextLevelButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void GetRestartLevelButton()
    {
        //
    }

    private void GetCurrentArrowCount()
    {
        arrowCountText.text = ArrowManager.Instance.CurrentArrowCount.ToString();
    }

    private void OnFinishGame()
    {

    }


    #endregion

    #region Callbacks
    private void OnTouchPositionChanged(Touch touch)
    {
        holdAndMovePanel.SetActive(false);
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
                slideAndMovePanel.SetActive(true);
                break;
            case GameStates.Success:
                successPanel.SetActive(true);
                break;
        }
    }

    private void OnScoreChange()
    {
        GetCurrentScore();
    }


    #endregion
}