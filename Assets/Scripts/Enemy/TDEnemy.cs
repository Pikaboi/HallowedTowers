using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
//Add the custom affinity namespace
using Affinity = affinity.Affinity;

public class TDEnemy : MonoBehaviour
{
    public enum TargetState
    {
        GOAL,
        PLAYER
    };

    //Basic Variables 
    public NavMeshAgent m_agent;
    public float m_moveSpeed;
    public float m_attackPower;
    public float m_health;
    public float m_debuffMultiplier = 1.0f;

    public Affinity m_affinity = Affinity.MONSTER;
    public TargetState m_targetState = TargetState.GOAL;

    //Status effects
    public bool m_SpeedDropped = false;
    public bool m_PermaSpeedDrop = false;

    //Damage over time control
    public bool damageOverTime = false;
    public float AfflictionTime = 5.0f;
    public float AfflictionTimer = 0.0f;
    public float dotTimer = 1.0f;
    public float speedDecreaseTimer = 10.0f;
    public float DOTDamage = 0.0f;

    public float aggressionTimer = 15.0f;
    public float maxAggressionTimer = 15.0f;

    public bool aggro = false;

    public bool m_Stunned = false;
    public float m_StunTimer = 2.0f;
    public float m_StunImmuneTimer = 5.0f;

    public bool m_Pushed = false;
    public float m_PushTimer = 1.0f;

    public ParticleSystem m_Particle;

    //Animation
    public Animator m_anim;

    public PlayerResourceManager m_resource;

    public WorldCharacter m_Player;

    public Transform m_Destination;

    public AudioSource m_Damage;

    // Start is called before the first frame update
    public virtual void Start()
    {
        m_agent = GetComponent<NavMeshAgent>();
        m_agent.speed = m_moveSpeed;

        m_agent.destination = m_Destination.position;
        m_resource = FindObjectOfType<PlayerResourceManager>();

        m_Player = FindObjectOfType<WorldCharacter>();

        m_debuffMultiplier = 1.0f;

        aggressionTimer = maxAggressionTimer;

        m_Particle.Stop();
    }

    // Update is called once per frame
    public virtual void Update()
    {
        PushControl();
        Aggression();
        Stun();
        DoTControl();
        ControlSpeedDrop();
        CheckDeath();
    }

    public void PushControl()
    {
        if (m_Pushed)
        {
            m_PushTimer -= Time.deltaTime;
            GetComponent<Rigidbody>().MovePosition(transform.position - (m_agent.velocity.normalized * 0.25f));

            if (m_PushTimer <= 0)
            {
                m_Pushed = false;
                m_PushTimer = 1.0f;
            }
        }
    }

    public void Push()
    {
        m_Pushed = true;
    }

    public void Stun()
    {
        if (m_Stunned)
        {
            m_agent.speed = 0;
            m_StunTimer -= Time.deltaTime;

            if (m_StunTimer < 0.0f)
            {
                m_Stunned = false;
                m_agent.speed = m_moveSpeed;
            }

        }
        else {
            m_StunImmuneTimer -= Time.deltaTime;
        }
    }

    public void Aggression()
    {
        switch (m_targetState)
        {
            case TargetState.GOAL:
                m_agent.destination = m_Destination.position;
                if(m_anim != null)
                {
                    m_anim.SetBool("Attack", false);
                }
                break;
            case TargetState.PLAYER:
                m_agent.destination = m_Player.transform.position;
                if (m_anim != null)
                {
                    m_anim.SetBool("Attack", true);
                }
                break;
        }

        if(m_Player.m_health <= 0 || Vector3.Distance(m_Player.transform.position, transform.position) > 20.0f || aggressionTimer < 0.0f)
        {
            aggro = false;
            aggressionTimer = maxAggressionTimer;
        }

        if(aggro)
        {
            m_targetState = TargetState.PLAYER;
            aggressionTimer -= Time.deltaTime;
        } else
        {
            m_targetState = TargetState.GOAL;
        }
    }

    public void AggroRoll()
    {
        int rand = Random.Range(0, 99);

        if(rand < 30)
        {
            aggro = true;
        }

    }

    public void DoTControl()
    {
        if (damageOverTime)
        {
            AfflictionTimer -= Time.deltaTime;
            if (AfflictionTimer > 0.0f)
            {
                Affliction();
            }
        }

    }

    public void ControlSpeedDrop()
    {
        if (m_SpeedDropped)
        {
            speedDecreaseTimer -= Time.deltaTime;
            if (speedDecreaseTimer <= 0)
            {
                m_agent.speed *= 2;
                m_SpeedDropped = false;
            }
        }

    }

    public void CheckDeath()
    {
        if (m_health <= 0.0f)
        {
            if (m_anim == null)
            {
                if (!m_Damage.isPlaying)
                {
                    Destroy(gameObject);
                }
            }
            else
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

    public void Debuff(float _multiplier, Affinity _affinity)
    {
        if (_multiplier * AffinityCheck(_affinity) > m_debuffMultiplier)
        {
            m_debuffMultiplier = _multiplier * AffinityCheck(_affinity);
        }
    }

    public void RemoveDebuff()
    {
        m_debuffMultiplier = 1.0f;
    }

    //For road spikes
    /*public void SpikesDamage(Spikes _spike)
    {
        m_resource.AddMoney(_spike.m_attack * AffinityCheck(_spike.m_affinity) * m_debuffMultiplier);
        m_health -= _spike.m_attack * AffinityCheck(_spike.m_affinity) * m_debuffMultiplier;
        _spike.lowerResistance();
        m_Damage.Play();

        if (_spike.getSlow() && !m_SpeedDropped)
        {
            m_agent.speed = m_agent.speed / 2;
            m_SpeedDropped = true;
        }
    }*/

    public void Affliction()
    {
        dotTimer -= Time.deltaTime;
        if(dotTimer <= 0.0f)
        {
            m_health -= DOTDamage;
            m_Damage.Play();
            dotTimer = 1.0f;
        }
    }

    /*public void DamageEnemy(float damage, Affinity _affinity)
    {
        float trueDamage = damage * AffinityCheck(_affinity) * m_debuffMultiplier;
        m_resource.AddMoney(trueDamage);
        m_health -= trueDamage;
        m_Damage.Play();
    }*/

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

    public void InflictDOT(bool _inflict, float attack)
    {
        if (_inflict)
        {
            damageOverTime = _inflict;
            DOTDamage = attack;
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
                m_resource.AddMoney(Mathf.Floor(m_health * 1.5f));
                m_health = 0;
                m_Damage.Play();
            }
        }
    }

    public void SlowDebuff()
    {
        if (!m_SpeedDropped)
        {
            m_agent.speed = m_agent.speed / 2;
            m_SpeedDropped = true;
        }
    }

    public void ParticleColorChange(Affinity _affinity)
    {
        float val = AffinityCheck(_affinity);

        if(val == 1.2f)
        {
            m_Particle.startColor = Color.green;
        }

        if(val == 0.8f)
        {
            m_Particle.startColor = Color.red;
        }

        if(val == 1.0f)
        {
            m_Particle.startColor = Color.gray;
        }
    }
}
