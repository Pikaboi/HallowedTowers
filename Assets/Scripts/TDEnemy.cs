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

    public bool m_SpeedDropped = false;

    public bool damageOverTime = false;
    public float AfflictionTime = 5.0f;
    public float AfflictionTimer = 0.0f;

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
        if(damageOverTime)
        {
            AfflictionTimer -= Time.deltaTime;
            if (AfflictionTimer > 0.0f)
            {
                Affliction();
            }
        }

        if(m_health <= 0.0f)
        {
            Destroy(gameObject);
        }
    }

    public void OnCollisionEnter(Collision collision)
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

    //For road spikes
    public void OnTriggerEnter(Collider other)
    {
        //We are putting the spikes on the bullet layer
        if(other.gameObject.tag == "Hazard")
        {
            m_health--;
            other.gameObject.GetComponent<Spikes>().lowerResistance();

            if (other.gameObject.GetComponent<Spikes>().getSlow() && !m_SpeedDropped)
            {
                m_agent.speed = m_agent.speed / 2;
                m_SpeedDropped = true;
            }
        }
    }

    public void Affliction()
    {
        m_health--;
    }

    public void DamageEnemy(float damage, bool _Dot)
    {
        m_health -= damage;
        damageOverTime = _Dot;
        AfflictionTimer = AfflictionTime;
    }
}
