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
    
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        m_OGFireRate = m_fireRate;
        m_OGAttack = m_attack;

        if (Path2UG2)
        {
            GetComponentInParent<TDTowerManager>().m_AffinityDiscount = 0.5f;
        }
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
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

}
