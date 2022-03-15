using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using affinity;

public class TDProjectileKraken : TDProjectile
{
    TDEnemy m_target;
    public float homingRange;

    //Upgrade Flags
    public bool Path1UG2;
    /// <summary>
    /// Change Movement to instead home in on an enemy
    /// </summary>

    public bool Path2UG1;
    /// <summary>
    /// Inflict Knockback Using Knockback function
    /// </summary>

    public bool Path2UG2;
    /// <summary>
    /// Affinity Damage Boost
    /// </summary>

    public bool Path2UG3;
    /// <summary>
    /// Damage increased to enemies inflicted with slow
    /// </summary>

    public bool Path3UG1;
    /// <summary>
    /// Damage Increased based on distance from base tower
    /// </summary>

    public bool Path3UG2;
    /// <summary>
    /// Gain Candy based on how far the bullet traveled
    /// </summary>
    
    public bool Path3UG3;
    /// <summary>
    /// Affinity check is overriden at far range
    /// </summary>

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        if (m_Tower != null)
        {
            if (Vector3.Distance(transform.position, m_Tower.transform.position) > m_range)
            {
                Destroy(gameObject);
            }

            if (m_target != null)
            {
                if (Path1UG2)
                {
                    transform.LookAt(m_target.transform.position);
                    m_rigidbody.velocity = transform.forward * m_Speed;
                }
            }
        }
        else
        {
            //For cases without a tower or from the player
            if (Vector3.Distance(transform.position, ogPos) > m_range)
            {
                Destroy(gameObject);
            }
        }
    }

    public void getTarget(TDEnemy _enem)
    {
        m_target = _enem;
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
                    if (Path2UG2)
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
                    if (Path2UG2)
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
                    if (Path2UG2)
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
            if (Path3UG1)
            {
                //Absolute to make sure its always a positive increase to damage
                damage += Mathf.RoundToInt(Vector3.Distance(transform.position, m_Tower.transform.position));
            }

            float trueDamage = damage * AffinityCheck(_enemy.m_affinity) * _enemy.m_debuffMultiplier;

            if (Path3UG3)
            {
                if (Vector3.Distance(transform.position, m_Tower.transform.position) > 17.0f)
                {
                    trueDamage = damage * 1.2f * _enemy.m_debuffMultiplier;
                }
            }

            if (Path2UG3)
            {
                if (_enemy.m_SpeedDropped || _enemy.m_PermaSpeedDrop)
                {
                    trueDamage = trueDamage * 1.2f;
                }
            }

            _enemy.m_resource.AddMoney(Mathf.Round(Mathf.Min(trueDamage * 1.5f, _enemy.m_health * 1.5f)));

            if (Path3UG2)
            {
                _enemy.m_resource.AddMoney(Mathf.RoundToInt(Vector3.Distance(transform.position, m_Tower.transform.position)));
            }

            _enemy.m_health -= trueDamage;

            if (Path2UG1)
            {
                _enemy.Push();
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
                if (_enemy.m_deathEffect != null)
                {
                    _enemy.m_deathEffect.Play();
                }
                _enemy.m_deathParticle.Play();
            }
        }
    }
}
