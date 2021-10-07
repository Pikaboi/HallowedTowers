using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Add the custom affinity namespace
using Affinity = affinity.Affinity;

public class TDMelee : MonoBehaviour
{
    Rigidbody m_rigidbody;
    public float m_attack;
    public Affinity m_affinity;
    [SerializeField] private GameObject m_Tower;

    float m_Timer;

    public bool m_CanOHKO;
    // Start is called before the first frame update
    private void Start()
    {
        m_rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (m_Tower != null)
        {
            m_Timer += 360 * Time.deltaTime;
            transform.RotateAround(m_Tower.transform.position, Vector3.up, 360 * Time.deltaTime);

            if (m_Timer > 360)
            {
                Destroy(gameObject);
            }
        }
    }

    public void InheritFromTower(float attack, GameObject tower)
    {
        m_attack = attack;
        m_Tower = tower;
    }

    public virtual void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<TDEnemy>().DamageEnemy(m_attack);
            collision.gameObject.GetComponent<TDEnemy>().InstantKill(m_CanOHKO);
        }
    }
}
