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
    private TextMeshPro arrowCountText;
    #endregion

    #region Variables

    #endregion

    #region Props

    #endregion

    #region Unity Methods
    private void Start()
    {
        holdAndMovePanel.SetActive(true);
        InputController.Instance.TouchPositionChanged += OnTouchPositionChanged;
        GetCurrentLevel();
        GetCurrentScore();
        PlayerController.Instance.ArrowCountChanged += OnArrowCountChanged;
        arrowCountText.text = "1";
    }



    #endregion

    #region Methods
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
    private void GetCurrentArrowCount()
    {
        arrowCountText.text = ArrowManager.Instance.CurrentArrowCount.ToString();
    }

    #endregion

    #region Callbacks
    private void OnTouchPositionChanged(float obj)
    {
        holdAndMovePanel.SetActive(false);
        arrowCountText.gameObject.SetActive(true);
        InputController.Instance.TouchPositionChanged -= OnTouchPositionChanged;

    }
    private void OnArrowCountChanged()
    {
        GetCurrentArrowCount();
    }

    #endregion
}