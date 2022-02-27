using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Add the custom affinity namespace
using Affinity = affinity.Affinity;

public class TDTowerProjectileCandycorn : TDProjectile
{
    //Upgrade Flags
    public bool Path1UG1;
    /// <summary>
    /// Path UG 1: Increased Damage to Monsters
    /// </summary>

    public bool Path1UG2;
    /// <summary>
    /// If Monster Affinity, slightly increase damage to other affinities
    /// </summary>
    
    //Path1UG3 is done on Tower End

    public bool Path2UG1;
    /// <summary>
    ///  Allows finishing blows to generate more candy
    /// </summary>

    public bool Path2UG2;
    /// <summary>
    /// Gain More Candy on advantage, but gain none on disadvantage
    /// </summary>

    public bool Path2UG3;
    /// <summary>
    /// Monster Classes Drop More Money 
    /// </summary>

    //Path 3 is done on tower end

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
    }

    public override float AffinityCheck(Affinity _affinity)
    {
        float multiplier = 1.0f;
        switch (_affinity)
        {
            case Affinity.MONSTER:
                //Neutral
                if (Path1UG1)
                {
                    multiplier = 1.2f;
                }
                else
                {
                    multiplier = 1.0f;
                }
                break;
            case Affinity.MAGIC:
                if (m_Affinity == Affinity.UNDEAD)
                {
                    //Damage Decrease
                    multiplier = 1.2f;
                }
                if (m_Affinity == Affinity.SOUL)
                {
                    //Damage Increase
                    multiplier = 0.8f;
                }
                if (Path1UG2)
                {
                    if(m_Affinity == Affinity.MONSTER)
                    {
                        multiplier = 1.1f;
                    }
                }
                break;
            case Affinity.UNDEAD:
                if (m_Affinity == Affinity.SOUL)
                {
                    //Damage Decrease
                    multiplier = 1.2f;
                }
                if (m_Affinity == Affinity.MAGIC)
                {
                    //Damage Increase
                    multiplier = 0.8f;
                }
                if (Path1UG2)
                {
                    if (m_Affinity == Affinity.MONSTER)
                    {
                        multiplier = 1.1f;
                    }
                }
                break;
            case Affinity.SOUL:
                if (m_Affinity == Affinity.MAGIC)
                {
                    //Damage Decrease
                    multiplier = 1.2f;
                }
                if (m_Affinity == Affinity.UNDEAD)
                {
                    //Damage Increase
                    multiplier = 0.8f;
                }
                if (Path1UG2)
                {
                    if (m_Affinity == Affinity.MONSTER)
                    {
                        multiplier = 1.1f;
                    }
                }
                break;
            default:
                multiplier = 1.0f;
                break;
        }
        return multiplier;
    }

    public override void DamageEnemy(float damage, TDEnemy _enemy)
    {
        if (_enemy.m_health > 0)
        {
            float trueDamage = damage * AffinityCheck(_enemy.m_affinity) * _enemy.m_debuffMultiplier;

            if (Path2UG2)
            {
                float val = AffinityCheck(_enemy.m_affinity);

                if (val == 1.2f)
                {
                    //Doubles money on advantage
                    _enemy.m_resource.AddMoney(Mathf.Round(Mathf.Min(trueDamage * 2.0f * 1.5f, _enemy.m_health * 2.0f * 1.5f)));
                }
                else if (val == 0.8f)
                {
                    //No Money on disadvantage
                    _enemy.m_resource.AddMoney(0);
                }
                else
                {
                    _enemy.m_resource.AddMoney(Mathf.Round(Mathf.Min(trueDamage * 1.5f, _enemy.m_health * 1.5f)));
                }

            }
            else
            {
                _enemy.m_resource.AddMoney(Mathf.Round(Mathf.Min(trueDamage * 1.5f, _enemy.m_health * 1.5f)));
            }

            if (Path2UG3 && _enemy.m_affinity == Affinity.MONSTER)
            {
                _enemy.m_resource.AddMoney(5);
            }

            _enemy.m_health -= trueDamage;

            if (_enemy.m_CurrentWeb != null && _enemy.m_CurrentWeb.Path2UG1)
            {
                _enemy.m_health -= _enemy.m_CurrentWeb.m_Attack;
                _enemy.m_resource.AddMoney(Mathf.Round(Mathf.Min(_enemy.m_CurrentWeb.m_Attack * 1.5f, _enemy.m_health * 1.5f)));
            }

            _enemy.ParticleColorChange(m_Affinity);
            _enemy.m_Particle.Play();

            if (_enemy.m_health <= 0 && Path2UG1)
            {
                _enemy.m_resource.AddMoney(25);
            }

            if (_enemy.m_health > 0)
            {
                _enemy.m_Damage.Play();
            }
            else
            {
                _enemy.m_Dead.Play();
                _enemy.m_deathParticle.Play();
            }
        }
    }
}
