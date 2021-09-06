using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TDProjectile : MonoBehaviour
{
    Rigidbody m_rigidbody;
    [SerializeField] private float m_range;
    public float m_attack;
    [SerializeField] private GameObject m_Tower;
    [SerializeField] private float m_Speed;

    Vector3 ogPos;
    // Start is called before the first frame update
    public virtual void Start()
    {
        m_rigidbody = GetComponent<Rigidbody>();
        m_rigidbody.AddForce(transform.forward * m_Speed, ForceMode.Impulse);

        ogPos = transform.position;
    }

    public void InheritFromTower(float range, float attack, GameObject tower)
    {
        m_range = range;
        m_attack = attack;
        m_Tower = tower;
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
        Destroy(gameObject);
    }
}
