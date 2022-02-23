using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TDTower_MiniPirate : TDTower_GhostPirate
{
    public TDTower_GhostPirate master;
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        getMasterStats();

        if (master.m_InRange)
        {
            m_FireTimer -= Time.deltaTime;

            if (m_FireTimer <= 0.0f)
            {
                float angleStartSplit = m_angleStart;
                //Loop through instantiation of multiple objects
                for (int i = 0; i < m_bulletCount; i++)
                {
                    GameObject bullet = Instantiate(m_Projectile, transform.position + transform.forward * 1.5f, m_aimer.transform.rotation);
                    bullet.transform.Rotate(new Vector3(0.0f, angleStartSplit, 0.0f));
                    bullet.GetComponent<TDProjectile>().InheritFromTower(m_TriggerRange, m_attack + (m_attack * m_atkBuff), gameObject, m_Affinity);
                    angleStartSplit += m_angleSplit;
                }

                m_FireTimer = m_fireRate - (m_fireRate * m_fireRateBuff);
            }
        }
    }

    private void getMasterStats()
    {
        m_TriggerRange = master.m_TriggerRange;
        m_Affinity = master.m_Affinity;
        m_attack = master.m_attack;
        m_atkBuff = master.m_atkBuff;
        m_bulletCount = master.m_bulletCount;
        m_fireRate = master.m_fireRate;
        m_fireRateBuff = master.m_fireRateBuff;
        m_angleSplit = master.m_angleSplit;
        m_angleStart = master.m_angleStart;
    }
}
