using System;
using UnityEngine;
using Utilities;

public class ScoreController : MonoSingleton<ScoreController>
{
    #region SerializedFields

    #endregion

    #region Variables

    private int currentScore = 0;
    private int finalScore;

    #endregion

    #region Props

    public int CurrentScore => currentScore;

    #endregion

    #region Events

    public event Action ScoreChange;

    #endregion

    #region Unity Methods

    private void Awake() 
    {
        currentScore = PlayerPrefs.GetInt("Score");
    }

    private void Start() 
    {
        GameManager.Instance.GameStatesChanged += OnGameStateChanged;
    }

    #endregion

    #region Methods
    public void IncreaseScore(int scoreValue)
    {
        currentScore += scoreValue;
        SaveManager.Instance.SaveScore(currentScore);
        ScoreChange?.Invoke();
    }

    public void IncreaseScore(float scoreValue)
    {
        currentScore = (int)(scoreValue * currentScore);
        SaveManager.Instance.SaveScore(currentScore);
        ScoreChange?.Invoke();
    }

    #endregion

    #region Callbacks

    private void OnGameStateChanged(GameStates newState)
    {
        if(newState == GameStates.Start)
        {
            currentScore = PlayerPrefs.GetInt("Score");
        }
    }

    #endregion
}