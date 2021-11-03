using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tail : MonoBehaviour
{
    [Header("General Settings")]
    public int length = 6;    
    public float targetDist = 0.25f;
    public float smoothSpeed = 0.02f;

    [Header("Wiggle Settings")]
    public float wiggleSpeed = 3;
    public float wiggleMagnitude = 10;

    [Header("References")]
    public Transform tailBase;
    public LineRenderer lineRend;
    public Transform targetDir;
    public SpriteRenderer sr;

    private int lastLength;
    private Vector3[] segments;
    private Vector3[] segmentV;
    private Quaternion startingRotation;

    private void Start()
    {
        lineRend.positionCount = length;
        segments = new Vector3[length];
        segmentV = new Vector3[length];
        startingRotation = transform.rotation;
    }
    private void Reset()
    {
        OnValidate();
    }
    private void OnValidate()
    {
        if (lineRend == null) lineRend = GetComponentInParent<LineRenderer>();
        if (tailBase == null) tailBase = transform;
        if (sr == null) sr = GetComponentInParent<SpriteRenderer>();
        if (targetDir == null) targetDir = transform.GetChild(0);

        if (lastLength != length)
        {
            lineRend.positionCount = length;
            segments = new Vector3[length];
            segmentV = new Vector3[length];
            lastLength = length;
        }
    }
    private void Update()
    {
        targetDir.localRotation = Quaternion.Euler(0, 0, Mathf.Sin(Time.time * wiggleSpeed) * wiggleMagnitude);

        //Flip the target direction if the sprite is flipped.
        //Note: The sprite gets flipped by the character controller.
        if (sr.flipX)
        {
            tailBase.rotation = startingRotation * Quaternion.Euler(0, 0, 180);
        } else
        {
            tailBase.rotation = startingRotation * Quaternion.Euler(0, 0, 0);
        }

        segments[0] = targetDir.position;

        for (int i = 1; i < segments.Length; i++)
        {
            segments[i] = Vector3.SmoothDamp(segments[i], segments[i - 1] + targetDir.right * targetDist, ref segmentV[i], smoothSpeed);
        }

        lineRend.SetPositions(segments);
    }
}
