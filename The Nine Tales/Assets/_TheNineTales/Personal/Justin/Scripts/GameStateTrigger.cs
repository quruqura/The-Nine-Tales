using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class GameStateTrigger : MonoBehaviour
{
    private Collider2D col;
    private SpriteRenderer sr;

    [Tooltip("The tag assigned to the player object. Leave empty if you want any tag to work.")]
    public string playerTag = "Player";

    public GameState desiredState;

    private void OnValidate()
    {
        if (col == null) col = GetComponent<Collider2D>();
        else if (!col.isTrigger) col.isTrigger = true;
    }

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        if (sr != null) sr.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == playerTag || string.IsNullOrEmpty(playerTag))
        {
            StateManager.SetState(desiredState);
        }
    }
}
