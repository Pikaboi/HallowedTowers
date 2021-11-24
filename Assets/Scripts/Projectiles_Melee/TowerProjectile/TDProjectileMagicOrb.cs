using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TDProjectileMagicOrb : TDProjectile
{
    //Path 1 UG1 is the DOT Boolean

    public bool Path1UG2;
    /// <summary>
    /// DOT strengthens / Weakens with Affinity
    /// </summary>

    public bool Path1UG3;
    /// <summary>
    ///  Bosses are affected more by DOT
    /// </summary>

    public bool Path2UG1;
    /// <summary>
    /// Increased Damage to enemies with a status effect
    /// </summary>

    public bool Path2UG2;
    /// <summary>
    /// Stunned Enemies are stunned slightly longer
    /// </summary>

    public bool Path2UG3;
    /// <summary>
    /// Increased damage to bosses with affinity disadvantage
    /// </summary>

    public bool Path3UG1;
    /// <summary>
    /// Explosion hits wider radius
    /// </summary>

    public bool Path3UG2;
    /// <summary>
    /// Explosion hits others in range for more damage
    /// </summary>

    public bool Path3UG3;
    /// <summary>
    /// Affinity of others in range is always treated as disadvantaged
    /// </summary>

    float m_blastRadius = 4.0f;

    public bool m_inflictDOT = false;
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();

        if (Path3UG1)
        {
            m_blastRadius = 8.0f;
        }
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
    }

    public override void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            DamageEnemy(m_attack, collision.gameObject.GetComponent<TDEnemy>(), false);

            if (Path1UG2)
            {
                collision.gameObject.GetComponent<TDEnemy>().InflictDOT(m_inflictDOT, (m_attack / 2) * AffinityCheck(collision.gameObject.GetComponent<TDEnemy>().m_affinity));
            } else
            {
                collision.gameObject.GetComponent<TDEnemy>().InflictDOT(m_inflictDOT, (m_attack / 2));
            }
        }

        Collider[] cols = Physics.OverlapSphere(transform.position, m_blastRadius);

        foreach (Collider c in cols)
        {
            if (c.gameObject.tag == "Enemy" && c.gameObject != collision.gameObject)
            {
                if (Path3UG2)
                {
                    //We dont allow Path1UG2 here since we dont crosspath!
                    DamageEnemy(m_attack / 1.5f, c.gameObject.GetComponent<TDEnemy>(), true);
                    c.GetComponent<TDEnemy>().InflictDOT(m_inflictDOT, m_attack / 3);
                }
                else
                {
                    DamageEnemy(m_attack / 2, c.gameObject.GetComponent<TDEnemy>(), true);
                    c.GetComponent<TDEnemy>().InflictDOT(m_inflictDOT, m_attack / 4);

                    if (Path1UG2)
                    {
                        collision.gameObject.GetComponent<TDEnemy>().InflictDOT(m_inflictDOT, (m_attack / 4) * AffinityCheck(collision.gameObject.GetComponent<TDEnemy>().m_affinity));
                    }
                    else
                    {
                        collision.gameObject.GetComponent<TDEnemy>().InflictDOT(m_inflictDOT, (m_attack / 4));
                    }
                }
            }
        }

        Destroy(gameObject);
    }

    public void DamageEnemy(float damage, TDEnemy _enemy, bool _AOETarget)
    {
        if (_enemy.m_health > 0)
        {
            float trueDamage = damage * AffinityCheck(_enemy.m_affinity) * _enemy.m_debuffMultiplier;

            if (_AOETarget && Path3UG3)
            {
                trueDamage = damage * 1.2f * _enemy.m_debuffMultiplier;
            }

            if (Path2UG1)
            {
                if (_enemy.m_PermaSpeedDrop || _enemy.m_SpeedDropped || _enemy.m_Stunned)
                {
                    trueDamage = trueDamage * 1.2f;
                }
            }

            if (Path2UG2)
            {
                if (_enemy.m_Stunned)
                {
                    _enemy.m_StunTimer += 0.5f;
                }
            }

            _enemy.m_resource.AddMoney(Mathf.Floor(Mathf.Min(trueDamage * 1.5f, _enemy.m_health * 1.5f)));
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

