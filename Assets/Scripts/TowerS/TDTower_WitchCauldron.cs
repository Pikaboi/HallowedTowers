using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TDTower_WitchCauldron : TDTower
{
    //NOTE:
    //m_Attack and m_FireRate affect how its buffs work
    //Not how this tower attacks

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        Collider[] TowersInRange = Physics.OverlapSphere(transform.position, m_TriggerRange);
        
        foreach(Collider c in TowersInRange)
        {
            if(c.gameObject.GetComponent<TDTower>() != null)
            {
                if (c.gameObject.GetComponent<TDTower>().m_Affinity == m_Affinity && c.gameObject.GetComponent<TDTowerBuff>() == null && c.gameObject.GetComponent<TDTower_WitchCauldron>() == null) {
                    c.gameObject.AddComponent<TDTowerBuff>();
                }
            }
        }
    }

    //So buffs turn off when sold
    public void OnDestroy()
    {
        Collider[] TowersInRange = Physics.OverlapSphere(transform.position, m_TriggerRange);

        foreach (Collider c in TowersInRange)
        {
            if (c.gameObject.GetComponent<TDTower>() != null)
            {
                if (c.gameObject.GetComponent<TDTower>().m_Affinity == m_Affinity && c.gameObject.GetComponent<TDTower_WitchCauldron>() == null)
                {
                    //c.gameObject.GetComponent<TDTower>().RemoveBuff(m_attack, m_fireRate);
                }
            }
        }
    }

    public override void levelUp()
    {
        //The cauldron level up boosts range instead of offensive
        //Since it has no offensive prescence
        m_TriggerRange += 0.5f;
        m_Trigger.radius = m_TriggerRange;
        m_level++;
    }
}
