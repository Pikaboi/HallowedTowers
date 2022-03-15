using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TDProjectileTank : TDProjectile
{
    //Path 1 manipulates the Peirce Count

    public bool Path2UG1;
    /// <summary>
    /// First Target is dealt double damage if in a Affinity Disadvantage
    /// </summary>

    public bool Path2UG2;
    /// <summary>
    ///  Pushes the first target with the cannon
    /// </summary>

    public bool Path2UG3;
    /// <summary>
    /// Triple Damage against bosses
    /// </summary>

    public bool Path3UG1;
    /// <summary>
    /// Enemies hit are stunned for a short time
    /// </summary>

    public bool Path3UG2;
    /// <summary>
    /// Increased stun for those with disadvantage
    /// </summary>

    public bool Path3UG3;
    /// <summary>
    /// Can now stun those with advantage, but it is weaker
    /// </summary>

    public int m_PeirceCount;
    public int m_MaxPeirce;
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

    public override void OnCollisionEnter(Collision collision)
    {
        //We dont use OnCollisionEnter for peirce so we override the function
    }

    public override void DamageEnemy(float damage, TDEnemy _enemy)
    {
        if (_enemy.m_health > 0)
        {
            float trueDamage = damage * AffinityCheck(_enemy.m_affinity) * _enemy.m_debuffMultiplier;

            if (Path2UG3 && _enemy.BossBool && m_PeirceCount == m_MaxPeirce)
            {
                trueDamage *= 3;
            }

            if (Path2UG1 && AffinityCheck(_enemy.m_affinity) == 1.2f && m_PeirceCount == m_MaxPeirce)
            {
                trueDamage *= 2;
            }

            if (Path2UG2 && m_PeirceCount == m_MaxPeirce)
            {
                _enemy.Push();
            }

            if (Path3UG1 && _enemy.m_StunImmuneTimer < 0 && !_enemy.m_Stunned)
            {
                _enemy.m_Stunned = true;

                if (Path3UG3 && AffinityCheck(_enemy.m_affinity) == 0.8f)
                {
                    _enemy.m_StunTimer = 1.0f;
                }
                else if (AffinityCheck(_enemy.m_affinity) == 0.8f)
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

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            DamageEnemy(m_attack, other.gameObject.GetComponent<TDEnemy>());
            m_PeirceCount--;
        }
    }
}
