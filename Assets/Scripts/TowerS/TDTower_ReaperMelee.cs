using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TDTower_ReaperMelee : TDTower
{
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        CheckEnemies();

        m_attack = gameObject.GetComponentInParent<TDTower>().m_attack;
        Debug.Log(gameObject.GetComponentInParent<TDTower>());
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
