using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Add the custom affinity namespace
using Affinity = affinity.Affinity;

public class TDMelee : MonoBehaviour
{
    Rigidbody m_rigidbody;
    public float m_attack;
    public Affinity m_affinity;
    [SerializeField] private GameObject m_Tower;

    float m_Timer;

    public bool m_CanOHKO;
    /// <summary>
    /// Path 1 UG 1
    /// Adds the critical skill to the scythe
    /// </summary>

    public bool m_CriticalBoost;
    /// <summary>
    /// Path 1 UG 3
    /// If boolean is active, crit chance increase
    /// Multiplier is increased
    /// </summary>

    // Start is called before the first frame update
    private void Start()
    {
        m_rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (m_Tower != null)
        {
            m_Timer += 360 * Time.deltaTime;
            transform.RotateAround(m_Tower.transform.position, Vector3.up, 360 * Time.deltaTime);

            if (m_Timer > 360)
            {
                Destroy(gameObject);
            }
        }
    }

    public void InheritFromTower(float attack, GameObject tower, Affinity affinity)
    {
        m_attack = attack;
        m_Tower = tower;
        m_affinity = affinity;
    }

    public virtual void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            float critChance = Critical(m_CanOHKO);
            DamageEnemy(m_attack * critChance, collision.gameObject.GetComponent<TDEnemy>());
        }
    }

    public float Critical(bool _inflict)
    {
        if (_inflict)
        {
            int rand = Random.Range(0, 99);

            if (m_CriticalBoost)
            {
                if (rand < 50)
                {
                    return 4.0f;
                }
                else
                {
                    return 1.0f;
                }
            }
            else
            {
                if (rand < 25)
                {
                    return 3.0f;
                }
                else
                {
                    return 1.0f;
                }
            }
        } else
        {
            return 1.0f;
        }
    }

    public virtual void DamageEnemy(float damage, TDEnemy _enemy)
    {
        float trueDamage = damage * AffinityCheck(_enemy.m_affinity) * _enemy.m_debuffMultiplier;
        _enemy.m_resource.AddMoney(Mathf.Round(Mathf.Min(trueDamage * 1.5f, _enemy.m_health * 1.5f)));
        _enemy.m_health -= trueDamage;
        if (_enemy.m_health > 0)
        {
            _enemy.m_Damage.Play();
            _enemy.m_anim.SetTrigger("Hit");
        }
        else
        {
            _enemy.m_anim.SetTrigger("Hit");
            _enemy.m_Dead.Play();
            if (_enemy.m_deathEffect != null)
            {
                _enemy.m_deathEffect.Play();
            }
            _enemy.m_deathParticle.Play();
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
                if (m_affinity == Affinity.UNDEAD)
                {
                    //Damage Decrease
                    multiplier = 1.2f;
                }
                if (m_affinity == Affinity.SOUL)
                {
                    //Damage Increase
                    multiplier = 0.8f;
                }
                break;
            case Affinity.UNDEAD:
                if (m_affinity == Affinity.SOUL)
                {
                    //Damage Decrease
                    multiplier = 1.2f;
                }
                if (m_affinity == Affinity.MAGIC)
                {
                    //Damage Increase
                    multiplier = 0.8f;
                }
                break;
            case Affinity.SOUL:
                if (m_affinity == Affinity.MAGIC)
                {
                    //Damage Decrease
                    multiplier = 1.2f;
                }
                if (m_affinity == Affinity.UNDEAD)
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
