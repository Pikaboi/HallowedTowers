using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Add the custom affinity namespace
using Affinity = affinity.Affinity;

public class TDProjectile_Dragon : TDProjectile
{
    public bool Path1UG2;
    /// <summary>
    /// Disadvantage damage is increased
    /// </summary>

    public bool Path3UG2;
    /// <summary>
    /// Attack inflicts stun
    /// </summary>

    public bool Path3UG3;
    /// <summary>
    /// Increased boss damage
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
                    if (Path1UG2)
                    {
                        multiplier = 1.5f;
                    }
                    else
                    {
                        //Damage Decrease
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
                    if (Path1UG2)
                    {
                        multiplier = 1.5f;
                    }
                    else
                    {
                        //Damage Decrease
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
                    if (Path1UG2)
                    {
                        multiplier = 1.5f;
                    }
                    else
                    {
                        //Damage Decrease
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
            float trueDamage = damage * AffinityCheck(_enemy.m_affinity) * _enemy.m_debuffMultiplier;

            if (Path3UG3 && _enemy.BossBool)
            {
                trueDamage = damage * 1.5f * AffinityCheck(_enemy.m_affinity) * _enemy.m_debuffMultiplier;
            } 

            if (Path3UG2 && _enemy.m_StunImmuneTimer < 0 && !_enemy.m_Stunned)
            {
                _enemy.m_Stunned = true;

                if (AffinityCheck(_enemy.m_affinity) == 0.8f)
                {
                    _enemy.m_StunTimer = 0.0f;
                }
                else if (Path3UG2 && AffinityCheck(_enemy.m_affinity) == 1.2f)
                {
                    _enemy.m_StunTimer = 4.0f;
                }
                else
                {
                    _enemy.m_StunTimer = 2.0f;
                }

                _enemy.m_StunImmuneTimer = 5.0f;
            }

            _enemy.m_resource.AddMoney(Mathf.Round(Mathf.Min(trueDamage * 1.5f, _enemy.m_health * 1.5f)));
            _enemy.m_health -= trueDamage;
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
