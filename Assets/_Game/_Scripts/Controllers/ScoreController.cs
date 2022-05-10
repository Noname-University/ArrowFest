using System;
using UnityEngine;
using Utilities;

public class ScoreController : MonoSingleton<ScoreController>
{
    #region SerializedFields

    #endregion

    #region Variables

    private int currentScore = 0;

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

    #endregion

    #region Callbacks

    #endregion
}