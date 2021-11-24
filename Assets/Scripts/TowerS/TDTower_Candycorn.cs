using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Add the custom affinity namespace
using Affinity = affinity.Affinity;

public class TDTower_Candycorn : TDTower
{
    public bool Path1UG3;
    /// <summary>
    /// Increased Speed when bosses are active
    /// </summary>
    
    public bool Path3UG1;
    /// <summary>
    /// Can Copy the Affinity of a nearby Candy Shooter.
    /// </summary>
    
    public bool Path3UG2;
    /// <summary>
    /// Increased Attack when near Candy Shooters (capped at certain amount)
    /// </summary>
    public float groupBonus;

    public bool Path3UG3;
    /// <summary>
    /// Candy Shooters can shoot from the range of nearby shooters
    /// </summary>

    public float effectiveRange = 0;

    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        groupBonus = 0;
    }

    // Update is called once per frame
    public override void Update()
    {
        if (Path3UG1 && m_Affinity == Affinity.MONSTER)
        {
            //I have no clue why i need to set the radius to 1 but uh yeah
            Collider[] g = Physics.OverlapSphere(transform.position, 1);

            //has to be seperate since we only want 1
            foreach (Collider c in g)
            {
                if (c.gameObject.GetComponent<TDTower_Candycorn>() != null && c.gameObject != this.gameObject)
                {
                    m_Affinity = c.gameObject.GetComponent<TDTower_Candycorn>().m_Affinity;
                    break;
                }
            }
        }

        if (Path3UG2)
        {
            //I have no clue why i need to set the radius to 1 but uh yeah
            Collider[] g = Physics.OverlapSphere(transform.position, 1);

            float val = 0;
            foreach (Collider c in g)
            {
                if (c.gameObject.GetComponent<TDTower_Candycorn>() != null && c.gameObject != this.gameObject)
                {
                    val += 5;
                }
            }

            groupBonus = val;
        }

        CheckEnemies();
        Aim();
        if (m_InRange)
        {
            m_FireTimer -= Time.deltaTime;

            if (m_FireTimer <= 0.0f)
            {
                GameObject bullet = Instantiate(m_Projectile, transform.position + transform.forward * 1.5f, m_aimer.transform.rotation);
                bullet.GetComponent<TDProjectile>().InheritFromTower(m_TriggerRange, m_attack + groupBonus + (m_attack * m_atkBuff), gameObject, m_Affinity);
                m_FireTimer = m_fireRate;
                if (GetComponentInParent<TDTowerManager>().m_ShootParticle != null)
                {
                    GetComponentInParent<TDTowerManager>().m_ShootParticle.Play();
                }
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

    public override void levelUp()
    {
        if (m_level < 20)
        {
            m_attack += 1;
            m_level++;
        }
    }
}
