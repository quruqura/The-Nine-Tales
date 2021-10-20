using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaser : MonoBehaviour
{
    GameObject m_Player;
    public float speed;

    void Start()
    {
        m_Player = Player.instance.gameObject;
    }


    void Update()
    {
        //Vector2 VelocityToTarget = (m_Player.transform.position - transform.position).normalized * speed;
        Vector2 VelocityToTarget = (m_Player.transform.position - transform.position) * 0.9f;
        GetComponent<Rigidbody2D>().velocity = VelocityToTarget;
    }
}
