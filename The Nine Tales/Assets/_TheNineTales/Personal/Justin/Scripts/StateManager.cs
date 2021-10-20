using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{

    public enum GameState { Platforming, Narrative, Dialogue, StillImage }

    private static GameState currentGameState;

    public static GameState CurrentGameState
    {
        get => currentGameState;
    }

    public static void SetState(GameState state)
    {
        switch(state)
        {
            case GameState.Narrative:

                break;
            case GameState.Platforming:

                break;
            case GameState.Dialogue:

                break;
            case GameState.StillImage:

                break;
        }
    }
}
