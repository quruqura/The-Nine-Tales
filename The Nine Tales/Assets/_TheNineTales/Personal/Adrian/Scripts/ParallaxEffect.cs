using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    public GameObject cam;
    public float followSpeedMultiplyer;
    private Vector3 camLastPos;

    void Awake()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera");

    }

    void Update()
    {
        //this.gameObject.transform.position = new Vector3(followSpeedMultiplyer * cam.transform.position.x, followSpeedMultiplyer * cam.transform.position.y, this.gameObject.transform.position.z);

        //this.gameObject.transform.position -= ((camLastPos - cam.transform.position) * followSpeedMultiplyer);
        this.gameObject.transform.position -= new Vector3(((camLastPos.x - cam.transform.position.x) * followSpeedMultiplyer),((camLastPos.y - cam.transform.position.y) * followSpeedMultiplyer),0);
        camLastPos = cam.transform.position;
    }
}
