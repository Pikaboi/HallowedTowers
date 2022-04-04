using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Barricade : MonoBehaviour
{
    public float m_maxTimer;
    private float m_timer;
    private bool m_moving = false;
    private bool m_moveBack = false;
    private PlayerResourceManager m_resource;
    private Vector3 ogPos;
    public float m_price;

    void Start()
    {
        m_timer = m_maxTimer;
        m_resource = FindObjectOfType<PlayerResourceManager>();

        ogPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_moving)
        {
            MoveToPosition();
        }

        if(m_moveBack)
        {
            MoveBackToStart();
        }
    }

    void MoveToPosition()
    {
        Vector3 posOnNavMesh = transform.position;
        posOnNavMesh.y = 0;
        NavMeshHit hit;

        if (!NavMesh.SamplePosition(posOnNavMesh, out hit, 1.0f, NavMesh.AllAreas))
        {
            transform.position += transform.forward * Time.deltaTime;
        } else
        {
            BarricadeTimer();
        }
    }

    void MoveBackToStart()
    {
        Vector3 posOnNavMesh = transform.position;
        posOnNavMesh.y = 0;
        NavMeshHit hit;

        if (Vector3.Distance(transform.position, ogPos) > 0.1f)
        {
            transform.position -= transform.forward * Time.deltaTime;
        } else
        {
            m_moveBack = false;
        }
    }

    void BarricadeTimer()
    {
        m_timer -= Time.deltaTime;

        if(m_timer < 0)
        {
            m_timer = m_maxTimer;
            m_moving = false;
            m_moveBack = true;
        }
    }

    public void PayBarricade()
    {
        if (m_resource.m_Money >= m_price)
        {
            m_resource.m_Money -= m_price;
            m_moving = true;
        }
    }

}
