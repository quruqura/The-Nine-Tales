using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class CameraZoomTrigger : MonoBehaviour
{
    private Collider2D col;

    [Tooltip("The camera to trigger the zoom on")]
    public CameraController cam;

    [Tooltip("Set to true if you want the camera to zoom in to a narrative size, or false for platforming size.")]
    public bool zoomIn;

    //[Tooltip("Set to true if you want the trigger zone to toggle the camera's zoom instead of set it. Setting to true makes \"Zoom In\" get ignored.")]
    //public bool toggle;

    [Tooltip("The tag assigned to the player object. Leave empty if you want any tag to work.")]
    public string playerTag = "Player";

    private void OnValidate()
    {
        if (col == null) col = GetComponent<Collider2D>();
        else if (!col.isTrigger) col.isTrigger = true;
    }

    private void Start()
    {
        if (cam == null) cam = Camera.main.GetComponent<CameraController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == playerTag || string.IsNullOrEmpty(playerTag))
        {
            cam.SetCameraZoom(zoomIn);
        }
    }
}
