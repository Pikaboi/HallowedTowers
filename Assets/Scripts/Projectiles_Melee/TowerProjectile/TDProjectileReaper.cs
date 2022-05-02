using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Add the custom affinity namespace
using Affinity = affinity.Affinity;

public class TDProjectileReaper : TDProjectile
{
    public bool Path2UG1;
    /// <summary>
    /// Affinity advantage if neutral
    /// </summary>

    public bool Path2UG3;
    /// <summary>
    /// Affinity bonus is now double damage
    /// but disadvantage halves damage
    /// </summary>

    public bool Path3UG1;
    /// <summary>
    /// Increased Boss Damage
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
                if (m_Affinity == _affinity && Path2UG1)
                {
                    if (Path2UG3)
                    {
                        multiplier = 2.0f;
                    }
                    else
                    {
                        multiplier = 1.2f;
                    }
                }
                else
                {
                    multiplier = 1.0f;
                }
                break;
            case Affinity.MAGIC:
                if (m_Affinity == Affinity.UNDEAD)
                {
                    if (Path2UG3)
                    {
                        multiplier = 2.0f;
                    }
                    else
                    {
                        //Damage Decrease
                        multiplier = 1.2f;
                    }
                }
                if (m_Affinity == Affinity.SOUL)
                {
                    if (Path2UG3)
                    {
                        multiplier = 0.5f;
                    }
                    else
                    {
                        //Damage Increase
                        multiplier = 0.8f;
                    }
                }
                if(m_Affinity == Affinity.MAGIC && Path2UG1)
                {
                    if (Path2UG3)
                    {
                        multiplier = 2.0f;
                    }
                    else
                    {
                        //Damage Decrease
                        multiplier = 1.2f;
                    }
                }
                break;
            case Affinity.UNDEAD:
                if (m_Affinity == Affinity.SOUL)
                {
                    if (Path2UG3)
                    {
                        multiplier = 2.0f;
                    }
                    else
                    {
                        //Damage Decrease
                        multiplier = 1.2f;
                    }
                }
                if (m_Affinity == Affinity.MAGIC)
                {
                    if (Path2UG3)
                    {
                        multiplier = 0.5f;
                    }
                    else
                    {
                        //Damage Increase
                        multiplier = 0.8f;
                    }
                }
                if (m_Affinity == Affinity.UNDEAD && Path2UG1)
                {
                    if (Path2UG3)
                    {
                        multiplier = 2.0f;
                    }
                    else
                    {
                        //Damage Decrease
                        multiplier = 1.2f;
                    }
                }
                break;
            case Affinity.SOUL:
                if (m_Affinity == Affinity.MAGIC)
                {
                    if (Path2UG3)
                    {
                        multiplier = 2.0f;
                    }
                    else
                    {
                        //Damage Decrease
                        multiplier = 1.2f;
                    }
                }
                if (m_Affinity == Affinity.UNDEAD)
                {
                    if (Path2UG3)
                    {
                        multiplier = 0.5f;
                    }
                    else
                    {
                        //Damage Increase
                        multiplier = 0.8f;
                    }
                }
                if (m_Affinity == Affinity.SOUL && Path2UG1)
                {
                    if (Path2UG3)
                    {
                        multiplier = 2.0f;
                    }
                    else
                    {
                        //Damage Decrease
                        multiplier = 1.2f;
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

            if (Path3UG1 && _enemy.BossBool)
            {
                trueDamage = damage * 1.5f * AffinityCheck(_enemy.m_affinity) * _enemy.m_debuffMultiplier;
            }

            _enemy.m_resource.AddMoney(Mathf.Round(Mathf.Min(trueDamage * 1.5f, _enemy.m_health * 1.5f)));
            _enemy.m_health -= trueDamage;

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
                _enemy.m_anim.SetTrigger("Hit");
            }
            else
            {
                _enemy.m_Dead.Play();
                _enemy.m_anim.SetTrigger("Hit");
                if (_enemy.m_deathEffect != null)
                {
                    _enemy.m_deathEffect.Play();
                }
                _enemy.m_deathParticle.Play();
            }
        }
    }
}
