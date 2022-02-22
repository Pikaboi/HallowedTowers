using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TDTower_WitchCauldron : TDTower
{
    //NOTE:
    //m_Attack affects how its buffs work
    //Not how this tower attacks

    public bool Path1UG1;
    /// <summary>
    /// Increases attack speed of towers in range
    /// </summary>

    public bool Path1UG2;
    /// <summary>
    /// Doubles the damage buff given to towers
    /// </summary>

    public bool Path1UG3;
    /// <summary>
    /// Decreases cost of tower upgrades based on current level
    /// </summary>

    public bool Path2UG1;
    /// <summary>
    /// Further boost player attack buff by 50%
    /// </summary>

    public bool Path2UG2;
    /// <summary>
    /// Players gradually recover health in the range of the cauldron
    /// </summary>

    public bool Path2UG3;
    /// <summary>
    /// Players attacks get a critical chance
    /// Reapers Scythes critical chance is higher
    /// (x3 Multiplier to that one attack)
    /// </summary>

    public bool Path3UG1;
    /// <summary>
    /// Increases debuff strength to enemies by 50%
    /// Allows towers and players to do more damage
    /// </summary>

    public bool Path3UG2;
    /// <summary>
    /// Enemies with a disadvantage are slowed down
    /// </summary>

    public bool Path3UG3;
    /// <summary>
    /// Enemies with a disadvantage take a small DOT based off the attack of the cauldron
    /// May need to be buffed later?
    /// </summary>

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
                    if (Path1UG1)
                    {
                        //UG1 adds the fire rate buff, based on m_attack as a decrease
                        if (Path1UG2)
                        {
                            //This increases damage boost by 2x
                            c.gameObject.GetComponent<TDTower>().Buff(m_attack * 2.0f, m_attack);
                        }
                        c.gameObject.GetComponent<TDTower>().Buff(m_attack, m_attack);
                    }
                    c.gameObject.GetComponent<TDTower>().Buff(m_attack, 0);

                    if (Path1UG3)
                    {
                        if (c.gameObject.GetComponent<TDTower>().GetComponentInParent<TDTowerManager>().m_UGDiscount < ((float)m_level / 100.0f))
                        {
                            c.gameObject.GetComponent<TDTower>().GetComponentInParent<TDTowerManager>().m_UGDiscount = ((float)m_level / 100.0f);
                        }
                    }

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

                if (Path1UG3)
                {
                    c.gameObject.GetComponent<TDTower>().GetComponentInParent<TDTowerManager>().m_UGDiscount = 0;
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
            if (Path3UG1)
            {
                //Increase the debuff by 20% when upgrade is active
                other.GetComponent<TDEnemy>().Debuff((m_attack * 1.5f) + 1, m_Affinity);
            }
            else
            {
                other.GetComponent<TDEnemy>().Debuff(m_attack + 1, m_Affinity);
            }

            if (other.GetComponent<TDEnemy>().AffinityCheck(m_Affinity) == 1.2f)
            {
                if (Path3UG2)
                {
                    other.GetComponent<TDEnemy>().SlowDebuff();
                }

                if (Path3UG3 && other.GetComponent<TDEnemy>().DOTDamage == 0)
                {
                    other.GetComponent<TDEnemy>().InflictDOT(true, m_attack);
                }
            }
        }

        if(other.gameObject.tag == "Player")
        {
            if (other.GetComponent<WorldCharacter>().m_WeaponStats != null)
            {
                if (Path2UG1)
                {
                    other.GetComponent<WorldCharacter>().m_WeaponStats.Buff(m_attack * 1.5f, m_Affinity);
                }
                else
                {
                    other.GetComponent<WorldCharacter>().m_WeaponStats.Buff(m_attack, m_Affinity);
                }

                if (Path2UG3)
                {
                    other.GetComponent<WorldCharacter>().m_WeaponStats.m_Critical = true;
                }
            }

            if (Path2UG2)
            {
                other.GetComponent<WorldCharacter>().Recover();
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

                other.GetComponent<WorldCharacter>().m_WeaponStats.m_Critical = false;
            }
        }
    }

}
