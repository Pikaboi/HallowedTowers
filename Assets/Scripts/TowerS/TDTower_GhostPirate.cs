using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TDTower_GhostPirate : TDTower
{
    public float m_angleSplit = 10.0f;
    public float m_angleStart = -20.0f;
    public int m_bulletCount = 5;

    public bool Path3UG3;
    /// <summary>
    /// Attack is boosted when a player is near the ship
    /// </summary>
    public float m_PlayerBoost;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        CheckEnemies();
        Aim();
        if (m_InRange)
        {
            m_FireTimer -= Time.deltaTime;

            if (m_FireTimer <= 0.0f)
            {
                float angleStartSplit = m_angleStart;
                //Loop through instantiation of multiple objects
                for(int i = 0; i < m_bulletCount; i++)
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

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<WorldCharacter>() != null && Path3UG3)
        {
            m_attack += m_PlayerBoost;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<WorldCharacter>() != null && Path3UG3)
        {
            m_attack -= m_PlayerBoost;
        }
    }
}
