using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using UnityEngine.UI;

public enum GameState { Platforming, Narrative, Dialogue, StillImage }

public class StateManager : MonoBehaviour
{
    public Player characterController;
    public GameState startingState = GameState.Dialogue;
    public Flowchart startingFlowchart;
    public Text stateText;

    private static Player cc;

    private static GameState currentGameState;

    public static GameState CurrentGameState
    {
        get => currentGameState;
    }

    public static bool debugMode = true;

    private static CameraController cam;

    private void Awake()
    {
        if(cc == null) cc = characterController;
    }

    private void Start()
    {
        if (cam == null) cam = Camera.main.GetComponent<CameraController>();

        SetState(startingState);
    }
    private void Update()
    {
        stateText.text = CurrentGameState.ToString();
    }

    public void ExitDialogueToPlatforming()
    {
        SetState(GameState.Platforming);
    }
    public void ExitDialogueToNarrative()
    {
        SetState(GameState.Narrative);
    }

    public static void SetState(GameState state)
    {
        currentGameState = state;

        if (CurrentGameState == GameState.Dialogue || CurrentGameState == GameState.StillImage)
        {
            cc.enabled = true;
        }

        switch(state)
        {
            case GameState.Narrative:
                cam.SetCameraZoom(true);
                cc.enabled = true;
                break;
            case GameState.Platforming:
                cam.SetCameraZoom(false);
                cc.enabled = true;
                break;
            case GameState.Dialogue:
                cam.SetCameraZoom(true);
                cc.enabled = false;
                break;
            case GameState.StillImage:
                cam.SetCameraZoom(true);
                cc.enabled = false;
                break;
        }
    }
}
