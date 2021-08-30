using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TDEnemy : MonoBehaviour
{
    //Basic Variables
    public NavMeshAgent m_agent;
    public float m_moveSpeed;
    public float m_attackPower;
    public float m_health;

    public Transform m_Destination;

    // Start is called before the first frame update
    public virtual void Start()
    {
        m_agent = GetComponent<NavMeshAgent>();
        m_agent.speed = m_moveSpeed;

        m_agent.destination = m_Destination.position;
    }

    // Update is called once per frame
    public virtual void Update()
    {
        
    }
}
