using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TDTower_ReaperMelee : TDTower
{
    public bool Path1UG2;
    /// <summary>
    /// Makes the shooter range unavailable
    /// However the scythe has more range
    /// and attack
    /// this bool sets the range
    /// </summary>

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();

        if (Path1UG2)
        {
            //gameObject.GetComponentInParent<TDTower>().m_TriggerRange = 0.5f;
            //gameObject.GetComponentInParent<TDTower>().m_Trigger.radius = gameObject.GetComponentInParent<TDTower>().m_TriggerRange;
        }
    }

    // Update is called once per frame
    public override void Update()
    {
        if (Path1UG2)
        {
            //gameObject.GetComponentInParent<TDTower>().m_TriggerRange = 0.5f;
            //gameObject.GetComponentInParent<TDTower>().m_Trigger.radius = gameObject.GetComponentInParent<TDTower>().m_TriggerRange;
        }

        CheckEnemies();

        m_attack = gameObject.GetComponentInParent<TDTower>().m_attack;
        m_atkBuff = GetComponentInParent<TDTower>().m_atkBuff;

        if (m_InRange)
        {
            m_FireTimer -= Time.deltaTime;

            if(m_FireTimer <= 0.0f)
            {
                GameObject go = Instantiate(m_Projectile, transform.position, Quaternion.Euler(Vector3.zero));
                go.GetComponent<TDMelee>().InheritFromTower(m_attack + (m_attack * m_atkBuff), gameObject, m_Affinity);
                m_FireTimer = m_fireRate - (m_fireRate * m_fireRateBuff);
            }
        }
    }
}
