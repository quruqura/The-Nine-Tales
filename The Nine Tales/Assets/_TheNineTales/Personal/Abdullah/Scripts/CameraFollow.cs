using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    GameObject m_Player;

    void Start()
    {
        m_Player = Player.instance.gameObject;
    }


    void Update()
    {

        gameObject.transform.position = new Vector3(m_Player.transform.position.x, transform.position.y, transform.position.z);
    }
}
