using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

public class GameManager : MonoSingleton<GameManager>
{
    public event Action<GameStates> GameStatesChanged;

    private GameStates currentGameState;
    public GameStates CurrentGameState => currentGameState;


    private void Start()
    {
        UpdateGameState(GameStates.Start);
    }



    public void UpdateGameState(GameStates newState)
    {
        currentGameState = newState;
        GameStatesChanged?.Invoke(newState);
    }
}
