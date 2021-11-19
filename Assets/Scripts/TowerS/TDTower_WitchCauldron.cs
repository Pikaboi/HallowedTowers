using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TDTower_WitchCauldron : TDTower
{
    //NOTE:
    //m_Attack affects how its buffs work
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
                if (c.gameObject.GetComponent<TDTower>().m_Affinity == m_Affinity && c.gameObject.GetComponent<TDTower_WitchCauldron>() == null)
                {
                    c.gameObject.GetComponent<TDTower>().Buff(m_attack);
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
                    c.gameObject.GetComponent<TDTower>().Debuff();
                }
            }

            if(c.gameObject.tag == "Enemy")
            {
                c.gameObject.GetComponent<TDEnemy>().RemoveDebuff();
            }

            if(c.gameObject.tag == "Player")
            {
                c.gameObject.GetComponent<WorldCharacter>().m_WeaponStats.Debuff();
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

    public void OnTriggerStay(Collider other)
    {
        if(other.GetComponent<TDEnemy>() != null)
        {
            other.GetComponent<TDEnemy>().Debuff(m_attack + 1, m_Affinity);
        }

        if(other.gameObject.tag == "Player")
        {
            if (other.GetComponent<WorldCharacter>().m_WeaponStats != null)
            {
                other.GetComponent<WorldCharacter>().m_WeaponStats.Buff(m_attack, m_Affinity);
            }
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<TDEnemy>() != null)
        {
            other.GetComponent<TDEnemy>().RemoveDebuff();
        }

        if (other.gameObject.tag == "Player")
        {
            if (other.GetComponent<WorldCharacter>().m_WeaponStats != null)
            {
                other.GetComponent<WorldCharacter>().m_WeaponStats.Debuff();
            }
        }
    }

}
