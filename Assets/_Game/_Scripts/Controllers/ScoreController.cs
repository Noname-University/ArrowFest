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

    #endregion

    #region Methods
    public void IncreaseScore(int scoreValue)
    {
        currentScore += scoreValue;
        ScoreChange?.Invoke();
    }

    public void IncreaseScore(float scoreValue)
    {
        currentScore = (int)(scoreValue * currentScore);
        ScoreChange?.Invoke();
    }

    #endregion

    #region Callbacks

    #endregion
}