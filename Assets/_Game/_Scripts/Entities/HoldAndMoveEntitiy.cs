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
        MoveEntitiy();

    }



    #endregion

    #region Methods
    private void MoveEntitiy()
    {
        transform.LeanMoveLocalX(-413.4f, 0.5f).setLoopPingPong();
    }

    #endregion

    #region Callbacks


    #endregion
}