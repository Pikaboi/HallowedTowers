using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TDTowerReaper : TDTower
{
    public bool Path2UG2;
    /// <summary>
    /// Lower the cost of affinity changes
    /// </summary>

    public bool Path3UG2;
    /// <summary>
    /// Boost the fire rate if an enemy in range
    /// has the affinity disadvantage
    /// </summary>
    public float m_AffinityFireRate;
    private float m_OGFireRate;

    public bool Path3UG3;
    /// <summary>
    /// Boost attack by a lot
    /// But only if there are no towers in its range
    /// </summary>
    public float m_SoloAttack;
    public float m_OGAttack;

    public bool shoot;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        m_OGFireRate = m_fireRate;
        m_OGAttack = m_attack;
        m_SoloAttack = m_OGAttack * 2;

        if (Path2UG2)
        {
            GetComponentInParent<TDTowerManager>().m_AffinityDiscount = 0.5f;
        }
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
                shoot = true;
                GameObject bullet = Instantiate(m_Projectile, transform.position + transform.forward * 1.5f, m_aimer.transform.rotation);
                bullet.GetComponent<TDProjectile>().InheritFromTower(m_TriggerRange, m_attack + (m_attack * m_atkBuff), gameObject, m_Affinity);
                m_FireTimer = m_fireRate - (m_fireRate * m_fireRateBuff);

                if (GetComponentInParent<TDTowerManager>().m_ShootParticle != null)
                {
                    GetComponentInParent<TDTowerManager>().m_ShootParticle.Play();
                }
            } else
            {
                shoot = false;
            }
        }

        //To get sub towers like Reapers Scythe updated
        TDTower[] childTowers = gameObject.GetComponentsInChildren<TDTower>();

        if (childTowers.Length > 0)
        {
            for (int i = 0; i < childTowers.Length; i++)
            {
                childTowers[i].SetAffinity(m_Affinity);
            }
        }
    }

    public override void CheckEnemies()
    {
        bool affinityInRange = false;
        bool towerInRange = false;

        Collider[] ObjsInRange = Physics.OverlapSphere(transform.position, m_TriggerRange);

        bool range = false;

        foreach (Collider Obj in ObjsInRange)
        {
            if (Obj.gameObject.tag == "Enemy")
            {
                range = true;

                if(Obj.gameObject.GetComponent<TDEnemy>().AffinityCheck(m_Affinity) == 1.2f && Path3UG2)
                {
                    affinityInRange = true;
                }
            }

            if(Obj.gameObject != this.gameObject && Obj.gameObject.GetComponent<TDTower>() != null && Path3UG3)
            {
                towerInRange = true;
            }

        }
        m_InRange = range;

        if (Path3UG2)
        {
            if (affinityInRange)
            {
                m_fireRate = m_AffinityFireRate;
            }
            else
            {
                m_fireRate = m_OGFireRate;
            }
        }

        if (Path3UG3)
        {
            if (towerInRange)
            {
                m_attack = m_OGAttack;
            }
            else
            {
                m_attack = m_SoloAttack;
            }
        }

    }

    public override void levelUp()
    {
        if (m_level < 20)
        {
            m_attack += 1;
            m_level++;
            m_OGAttack = m_attack;
            m_SoloAttack = m_OGAttack * 2;

            TDTower[] childTowers = gameObject.GetComponentsInChildren<TDTower>();

            if (childTowers.Length > 0)
            {
                for (int i = 0; i < childTowers.Length; i++)
                {
                    if(childTowers[i] != this)
                    {
                        childTowers[i].levelUp();
                    }
                }
            }
        }
    }

}
