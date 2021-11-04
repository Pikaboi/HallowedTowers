using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Add the custom affinity namespace
using Affinity = affinity.Affinity;

public class TDProjectile : MonoBehaviour
{
    Rigidbody m_rigidbody;
    [SerializeField] private float m_range;
    public float m_attack;
    [SerializeField] private GameObject m_Tower;
    [SerializeField] private float m_Speed;
    public Affinity m_Affinity;
    Vector3 ogPos;
    // Start is called before the first frame update
    public virtual void Start()
    {
        m_rigidbody = GetComponent<Rigidbody>();
        m_rigidbody.AddForce(transform.forward * m_Speed, ForceMode.Impulse);

        ogPos = transform.position;
    }

    public void InheritFromTower(float range, float attack, GameObject tower, Affinity affinity)
    {
        m_range = range;
        m_attack = attack;
        m_Tower = tower;
        m_Affinity = affinity;
    }

    // Update is called once per frame
    public virtual void Update()
    {
        if(m_Tower != null)
        {
            if (Vector3.Distance(transform.position, m_Tower.transform.position) > m_range)
            {
                Destroy(gameObject);
            }
        } else
        {
            //For cases without a tower or from the player
            if (Vector3.Distance(transform.position, ogPos) > m_range)
            {
                Destroy(gameObject);
            }
        }
    }

    public virtual void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            DamageEnemy(m_attack, collision.gameObject.GetComponent<TDEnemy>());

            //If its a players projectile
            if(m_Tower.GetComponent<PlayerWeapon>() != null)
            {
                collision.gameObject.GetComponent<TDEnemy>().AggroRoll();
            }

        }
        Destroy(gameObject);
    }

    public virtual void DamageEnemy(float damage, TDEnemy _enemy)
    {
        float trueDamage = damage * AffinityCheck(_enemy.m_affinity) * _enemy.m_debuffMultiplier;
        _enemy.m_resource.AddMoney(trueDamage);
        _enemy.m_health -= trueDamage;
        _enemy.m_Damage.Play();
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
