using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Add the custom affinity namespace
using Affinity = affinity.Affinity;

public class PlayerWeapon : MonoBehaviour
{
    public float m_Attack;
    public float m_atkBuff;
    public bool isMelee; //True = Melee, False = Range
    //Only add this if its a Ranged weapon
    public GameObject Bullet;
    public float m_BulletRange;
    public Affinity m_Affinity;
    public AudioClip m_audioClip;
    public ParticleSystem m_particle;
    public Transform shootpos;

    public virtual void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            DamageEnemy(m_Attack + (m_Attack * m_atkBuff), collision.gameObject.GetComponent<TDEnemy>());
            collision.gameObject.GetComponent<TDEnemy>().AggroRoll();
        }
    }

    public void Buff(float _buff, Affinity _affinity)
    {
        float mult = 1.0f;
        if(_affinity == m_Affinity)
        {
            mult = 1.2f;
        }

        if(_buff * mult > m_atkBuff)
        {
            m_atkBuff = _buff * mult;
        }
    }

    public void Debuff()
    {
        m_atkBuff = 0;
    }

    public virtual void DamageEnemy(float damage, TDEnemy _enemy)
    {
        float trueDamage = damage * AffinityCheck(_enemy.m_affinity) * _enemy.m_debuffMultiplier;
        _enemy.m_resource.AddMoney(trueDamage);
        _enemy.m_health -= trueDamage;
        _enemy.ParticleColorChange(m_Affinity);
        _enemy.m_Particle.Play();

        if (_enemy.m_health > 0)
        {
            _enemy.m_Damage.Play();
        } else
        {
            _enemy.m_Dead.Play();
        }
    }

    public virtual float AffinityCheck(Affinity _affinity)
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
                    multiplier = 1.2f;
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
                    multiplier = 1.2f;
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
                    multiplier = 1.2f;
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
}
