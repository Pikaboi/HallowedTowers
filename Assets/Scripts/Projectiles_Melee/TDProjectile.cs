using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Add the custom affinity namespace
using Affinity = affinity.Affinity;

public class TDProjectile : MonoBehaviour
{
    Rigidbody m_rigidbody;
    [SerializeField] private float m_range;
    public float m_attack;
    [SerializeField] private GameObject m_Tower;
    [SerializeField] private float m_Speed;
    public Affinity m_Affinity;
    Vector3 ogPos;
    // Start is called before the first frame update
    public virtual void Start()
    {
        m_rigidbody = GetComponent<Rigidbody>();
        m_rigidbody.AddForce(transform.forward * m_Speed, ForceMode.Impulse);

        ogPos = transform.position;
    }

    public void InheritFromTower(float range, float attack, GameObject tower, Affinity affinity)
    {
        m_range = range;
        m_attack = attack;
        m_Tower = tower;
        m_Affinity = affinity;
    }

    // Update is called once per frame
    public virtual void Update()
    {
        if(m_Tower != null)
        {
            if (Vector3.Distance(transform.position, m_Tower.transform.position) > m_range)
            {
                Destroy(gameObject);
            }
        } else
        {
            //For cases without a tower or from the player
            if (Vector3.Distance(transform.position, ogPos) > m_range)
            {
                Destroy(gameObject);
            }
        }
    }

    public virtual void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<TDEnemy>().DamageEnemy(m_attack, m_Affinity);

            //If its a players projectile
            if(m_Tower.GetComponent<PlayerWeapon>() != null)
            {
                collision.gameObject.GetComponent<TDEnemy>().AggroRoll();
            }

        }
        Destroy(gameObject);
    }
}
