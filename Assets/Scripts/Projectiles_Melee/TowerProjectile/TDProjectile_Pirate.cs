using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Add the custom affinity namespace
using Affinity = affinity.Affinity;

public class TDProjectile_Pirate : TDProjectile
{
    public bool Path2UG2;
    /// <summary>
    /// Disadvantage damage is increased
    /// </summary>

    public bool Path3UG1;
    /// <summary>
    /// Attack deals increased damage to bosses
    /// </summary>

    public bool Path3UG2;
    /// <summary>
    /// gets more money from enemy hits
    /// Based off attack
    /// </summary>

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
                multiplier = 1.0f;
                break;
            case Affinity.MAGIC:
                if (m_Affinity == Affinity.UNDEAD)
                {
                    //Damage Decrease
                    if (Path2UG2)
                    {
                        multiplier = 1.5f;
                    }
                    else
                    {
                        multiplier = 1.2f;
                    }
                }
                if (m_Affinity == Affinity.SOUL)
                {
                    //Damage Increase
                    multiplier = 0.8f;
                }
                break;
            case Affinity.UNDEAD:
                if (m_Affinity == Affinity.SOUL)
                {
                    //Damage Decrease
                    if (Path2UG2)
                    {
                        multiplier = 1.5f;
                    }
                    else
                    {
                        multiplier = 1.2f;
                    }
                }
                if (m_Affinity == Affinity.MAGIC)
                {
                    //Damage Increase
                    multiplier = 0.8f;
                }
                break;
            case Affinity.SOUL:
                if (m_Affinity == Affinity.MAGIC)
                {
                    //Damage Decrease
                    if (Path2UG2)
                    {
                        multiplier = 1.5f;
                    }
                    else
                    {
                        multiplier = 1.2f;
                    }
                }
                if (m_Affinity == Affinity.UNDEAD)
                {
                    //Damage Increase
                    multiplier = 0.8f;
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
            float trueDamage = 0;

            if(Path3UG1 && _enemy.BossBool)
            {
                trueDamage = (damage * 1.5f) * AffinityCheck(_enemy.m_affinity) * _enemy.m_debuffMultiplier;
            } else
            {
                trueDamage = damage * AffinityCheck(_enemy.m_affinity) * _enemy.m_debuffMultiplier;
            }

            _enemy.m_resource.AddMoney(Mathf.Round(Mathf.Min(trueDamage * 1.5f, _enemy.m_health * 1.5f)));
            _enemy.m_health -= trueDamage;

            if (Path3UG2)
            {
                _enemy.m_resource.AddMoney(Mathf.Round(Mathf.Min(m_attack * 1.5f)));
            }

            if (_enemy.m_CurrentWeb != null && _enemy.m_CurrentWeb.Path2UG1)
            {
                _enemy.m_health -= _enemy.m_CurrentWeb.m_Attack;
                _enemy.m_resource.AddMoney(Mathf.Round(Mathf.Min(_enemy.m_CurrentWeb.m_Attack * 1.5f, _enemy.m_health * 1.5f)));
            }

            _enemy.ParticleColorChange(m_Affinity);
            _enemy.m_Particle.Play();

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
