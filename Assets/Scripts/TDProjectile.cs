using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TDProjectile : MonoBehaviour
{
    Rigidbody m_rigidbody;
    [SerializeField] private float m_range;
    [SerializeField] private float m_attack;
    [SerializeField] private GameObject m_Tower;
    // Start is called before the first frame update
    void Start()
    {
        m_rigidbody = GetComponent<Rigidbody>();
        m_rigidbody.AddForce(transform.forward * 10.0f, ForceMode.Impulse);
    }

    public void InheritFromTower(float range, float attack, GameObject tower)
    {
        m_range = range;
        m_attack = attack;
        m_Tower = tower;
    }

    // Update is called once per frame
    void Update()
    {
        if(m_Tower != null)
        {
            if (Vector3.Distance(transform.position, m_Tower.transform.position) > m_range)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject);
        Destroy(gameObject);
    }
}
