using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameState State;
    public static event Action<GameState> OnGameStateChanged;

    // Start is called before the first frame update
    void Start()
    {
        ChangeState(GameState.StartGame);
    }

    public void ChangeState(GameState newState)
    {
        State = newState;
        switch (newState)
        {
            case GameState.StartGame:
                break;
            case GameState.CraftState:
                break;
            case GameState.EndGame:
                break;
        }
        OnGameStateChanged?.Invoke(newState);
    }

    // Update is called once per frame
    public enum GameState
    {
        StartGame,
        CraftState,
        EndGame
    }
}
