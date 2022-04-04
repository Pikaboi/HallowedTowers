using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Barricade : MonoBehaviour
{
    public float m_maxTimer;
    private float m_timer;
    private Vector3 OGPos;
    private bool m_moving;
    private PlayerResourceManager m_resource;
    public float m_price;

    void Start()
    {
        m_timer = m_maxTimer;
        OGPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_moving)
        {
            MoveToPosition();
        }
    }

    void MoveToPosition()
    {
        Vector3 posOnNavMesh = transform.position;
        posOnNavMesh.y = 0;
        NavMeshHit hit;

        if (NavMesh.SamplePosition(posOnNavMesh, out hit, 1.0f, NavMesh.AllAreas))
        {
            BarricadeTimer();
        }
        else
        {
            transform.position += transform.forward * Time.deltaTime;
        }
    }

    void BarricadeTimer()
    {
        m_timer -= Time.deltaTime;

        if(m_timer > 0)
        {
            m_timer = m_maxTimer;
            m_moving = false;
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
