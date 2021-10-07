using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TDTower_Kraken : TDTower
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
        Aim();
        if (m_InRange)
        {
            m_FireTimer -= Time.deltaTime;

            if (m_FireTimer <= 0.0f)
            {
                GameObject bullet = Instantiate(m_Projectile, transform.position + transform.forward * 1.5f, m_aimer.transform.rotation);
                bullet.GetComponent<TDProjectile>().InheritFromTower(m_TriggerRange, m_attack, gameObject, m_Affinity);
                GameObject bullet2 = Instantiate(m_Projectile, transform.position + transform.forward * 1.5f, Quaternion.Euler(m_aimer.transform.rotation.x, m_aimer.transform.rotation.y + 45.0f, m_aimer.transform.rotation.z));
                bullet2.GetComponent<TDProjectile>().InheritFromTower(m_TriggerRange, m_attack, gameObject, m_Affinity);
                GameObject bullet3 = Instantiate(m_Projectile, transform.position + transform.forward * 1.5f, Quaternion.Euler(m_aimer.transform.rotation.x, m_aimer.transform.rotation.y + 135.0f, m_aimer.transform.rotation.z));
                bullet3.GetComponent<TDProjectile>().InheritFromTower(m_TriggerRange, m_attack, gameObject, m_Affinity);
                m_FireTimer = m_fireRate;
            }
        }
    }
}
