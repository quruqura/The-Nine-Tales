using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
	public float smoothSpeed = 0.125f;

	public Vector3 offset;
	public bool calculateOffsetOnStart = true;

	public float platformingCameraSize;
	public float narrativeCameraSize = 5.3f;
	public float zoomTime = 0.7f;
	public AnimationCurve zoomCurve;

	private float zoomTimer;
	private float targetSize;
	private float startingSize;
	private bool zooming;
	public bool zoomedIn;

	private Camera cam;

    private void Start()
    {
		cam = GetComponent<Camera>();

		if(target == null)
        {
			target = GameObject.Find("Player").transform;
        }

		if (zoomedIn && narrativeCameraSize == 0) narrativeCameraSize = cam.orthographicSize; 
		else if(!zoomedIn && platformingCameraSize == 0) platformingCameraSize = cam.orthographicSize;
    }

    public void FixedUpdate()
	{
		Vector3 desiredPosition = target.position + offset;
		Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
		transform.position = smoothedPosition;

        if (zooming)
        {
			zoomTimer = Mathf.Clamp(zoomTimer + Time.deltaTime, 0, zoomTime);

			cam.orthographicSize = Mathf.Lerp(startingSize, targetSize, zoomCurve.Evaluate(zoomTimer / zoomTime));

			if (zoomTimer >= zoomTime) zooming = false;
			
			/*if (zoomedIn)
            {
				cam.orthographicSize = Mathf.Lerp(narrativeCameraSize, platformingCameraSize, zoomCurve.Evaluate(zoomTimer/zoomTime));
            } else
            {
				cam.orthographicSize = Mathf.Lerp(platformingCameraSize, narrativeCameraSize, zoomCurve.Evaluate(zoomTimer / zoomTime));
			}*/
        }
	}

	[ContextMenu("Zoom Out")]
	public void ZoomOut()
    {
		SetCameraZoom(platformingCameraSize);
    }
	[ContextMenu("Zoom In")]
	public void ZoomIn()
    {
		SetCameraZoom(narrativeCameraSize);
    }

	public void SetCameraZoom(bool zoomIn)
    {
		if (zoomIn) SetCameraZoom(narrativeCameraSize);
		else SetCameraZoom(platformingCameraSize);
    }

	public void SetCameraZoom(float zoom)
    {
		targetSize = zoom;
		startingSize = cam.orthographicSize;
		zooming = true;
		zoomTimer = 0;
    }
}
