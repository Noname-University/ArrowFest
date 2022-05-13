using System;
using UnityEngine;

public class HoldAndMoveEntitiy : MonoBehaviour
{
    #region SerializedFields

    #endregion

    #region Variables

    #endregion

    #region Props

    #endregion

    #region Unity Methods

    private void Start()
    {
        GameManager.Instance.GameStatesChanged += OnGameStatesChanged;
    }

    #endregion

    #region Methods
    private void MoveEntitiy()
    {
        transform.LeanMoveLocalX(-250f, 0.5f).setOnComplete(()=> transform.LeanMoveLocalX(250f, 0.5f).setLoopPingPong());
    }

    #endregion

    #region Callbacks

    private void OnGameStatesChanged(GameStates newState)
    {
        if (newState == GameStates.Start)
        {
            MoveEntitiy();
        }
    }


    #endregion
}