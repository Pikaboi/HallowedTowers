using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
//Add the custom affinity namespace
using Affinity = affinity.Affinity;

public class TDEnemy : MonoBehaviour
{
    //Basic Variables
    public NavMeshAgent m_agent;
    public float m_moveSpeed;
    public float m_attackPower;
    public float m_health;

    public Affinity m_affinity = Affinity.MONSTER;

    //Status effects
    public bool m_SpeedDropped = false;

    //Damage over time control
    public bool damageOverTime = false;
    public float AfflictionTime = 5.0f;
    public float AfflictionTimer = 0.0f;
    public float dotTimer = 1.0f;

    //Animation
    public Animator m_anim;

    [SerializeField] PlayerResourceManager m_resource;

    public Transform m_Destination;

    public AudioSource m_Damage;

    // Start is called before the first frame update
    public virtual void Start()
    {
        m_agent = GetComponent<NavMeshAgent>();
        m_agent.speed = m_moveSpeed;

        m_agent.destination = m_Destination.position;
        m_resource = FindObjectOfType<PlayerResourceManager>();
    }

    // Update is called once per frame
    public virtual void Update()
    {
        if(damageOverTime)
        {
            AfflictionTimer -= Time.deltaTime;
            if (AfflictionTimer > 0.0f)
            {
                Affliction();
            }
        }

        if(m_health <= 0.0f)
        {
            if (m_anim == null)
            {
                if (!m_Damage.isPlaying)
                {
                    Destroy(gameObject);
                }
            } else
            {
                m_anim.SetTrigger("Die");
                m_agent.enabled = false;
                Destroy(gameObject.GetComponent<Rigidbody>());

                if (m_anim.GetCurrentAnimatorStateInfo(0).IsName("Death") && m_anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1.0f)
                {
                    Destroy(gameObject);
                }
            }
        }
    }



    //For road spikes
    public void SpikesDamage(Spikes _spike)
    {
        m_resource.AddMoney(_spike.m_attack * AffinityCheck(_spike.m_affinity));
        m_health -= _spike.m_attack * AffinityCheck(_spike.m_affinity);
        _spike.lowerResistance();
        m_Damage.Play();

        if (_spike.getSlow() && !m_SpeedDropped)
        {
            m_agent.speed = m_agent.speed / 2;
            m_SpeedDropped = true;
        }
    }

    public void Affliction()
    {
        dotTimer -= Time.deltaTime;
        if(dotTimer <= 0.0f)
        {
            m_health--;
            m_Damage.Play();
            dotTimer = 1.0f;
        }
    }

    public void DamageEnemy(float damage, Affinity _affinity)
    {
        float trueDamage = damage * AffinityCheck(_affinity);
        m_resource.AddMoney(damage);
        m_health -= damage;
        m_Damage.Play();
    }

    public float AffinityCheck(Affinity _affinity)
    {
        float multiplier = 1.0f;
        switch (_affinity)
        {
            case Affinity.MONSTER:
                //Neutral
                multiplier = 1.0f;
                break;
            case Affinity.MAGIC:
                if(m_affinity == Affinity.UNDEAD)
                {
                    //Incoming Damage Reduced
                    multiplier = 0.8f;
                }
                if(m_affinity == Affinity.SOUL)
                {
                    //Incoming Damage Increased
                    multiplier = 1.2f;
                }
                break;
            case Affinity.UNDEAD:
                if (m_affinity == Affinity.SOUL)
                {
                    //Incoming Damage Reduced
                    multiplier = 0.8f;
                }
                if (m_affinity == Affinity.MAGIC)
                {
                    //Incoming Damage Increased
                    multiplier = 1.2f;
                }
                break;
            case Affinity.SOUL:
                if (m_affinity == Affinity.MAGIC)
                {
                    //Incoming Damage Reduced
                    multiplier = 0.8f;
                }
                if (m_affinity == Affinity.UNDEAD)
                {
                    //Incoming Damage Increased
                    multiplier = 1.2f;
                }
                break;
            default:
                multiplier = 1.0f;
                break;
        }
        return multiplier;
    }

    public void InflictDOT(bool _inflict)
    {
        if (_inflict)
        {
            damageOverTime = _inflict;
            AfflictionTimer = AfflictionTime;
            dotTimer = 1.0f;
        }
    }

    public void InstantKill(bool _inflict)
    {
        if (_inflict)
        {
            int rand = Random.Range(0, 99);

            if(rand < 25)
            {
                m_resource.AddMoney(m_health);
                m_health = 0;
                m_Damage.Play();
            }
        }
    }
}
