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

    [SerializeField] PlayerResourceManager m_resource;

    public Transform m_Destination;

    // Start is called before the first frame update
    public virtual void Start()
    {
        m_agent = GetComponent<NavMeshAgent>();
        m_agent.speed = m_moveSpeed;

        m_agent.destination = m_Destination.position;

        m_resource = FindObjectOfType<PlayerResourceManager>();
    }

    // Update is called once per frame
    public virtual void Update()
    {
        if(m_health <= 0.0f)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Check if a bullet
        if(collision.gameObject.layer == 14)
        {
            if(collision.gameObject.GetComponent<PlayerWeapon>() != null)
            {
                m_health -= collision.gameObject.GetComponent<PlayerWeapon>().m_Attack;
            }
            if (collision.gameObject.GetComponent<TDProjectile>() != null)
            {
                m_health -= collision.gameObject.GetComponent<TDProjectile>().m_attack;
            }
        }
    }
}
