using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TDTower : MonoBehaviour
{
    //Values all towers will share
    public SphereCollider m_Trigger;
    public float m_TriggerRange;
    //the projectile doesnt need to be a attacking type, can be anything
    //So I will set it up as a GameObject
    public GameObject m_Projectile;
    public float m_fireRate;
    public float m_attack;
    public float m_cost;

    public bool m_InRange;

    public float m_FireTimer;

    // Start is called before the first frame update
    public virtual void Start()
    {
        m_Trigger = GetComponent<SphereCollider>();
        m_Trigger.radius = m_TriggerRange;
        m_FireTimer = m_fireRate;
    }

    // Update is called once per frame
    public virtual void Update()
    {
        if (m_InRange)
        {
            m_FireTimer -= Time.deltaTime;
            
            if(m_FireTimer <= 0.0f)
            {
                Debug.Log("ah");
                Instantiate(m_Projectile, transform.position + transform.forward * 5.0f, transform.rotation);
                m_FireTimer = m_fireRate;
            }
        }
    }

    public virtual void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<TDEnemy>() != null)
        {
            m_InRange = true;
        }
    }

    public virtual void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<TDEnemy>() != null)
        {
            m_InRange = false;
        }
    }
}
