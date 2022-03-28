using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TDEnemyProjectile : MonoBehaviour
{
    public Rigidbody m_rigidbody;
    public float m_range;
    public float m_attack;
    public TDEnemy m_Enemy;
    public float m_Speed;
    public Vector3 ogPos;
    // Start is called before the first frame update
    public virtual void Start()
    {
        m_rigidbody = GetComponent<Rigidbody>();
        m_rigidbody.AddForce(transform.forward * m_Speed, ForceMode.Impulse);

        ogPos = transform.position;
    }

    public void InheritFromEnemy(TDEnemy Enemy)
    {
        m_Enemy = Enemy;
        m_attack = Enemy.m_attackPower;
    }

    // Update is called once per frame
    public virtual void Update()
    {
        if (m_Enemy != null)
        {
            if (Vector3.Distance(transform.position, m_Enemy.transform.position) > m_range)
            {
                Destroy(gameObject);
            }
        }
    }
}
