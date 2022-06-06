using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.VFX;
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
    public float m_playerAttackPower;
    public float m_health;
    public float m_debuffMultiplier = 1.0f;

    public Affinity m_affinity = Affinity.MONSTER;
    public TargetState m_targetState = TargetState.GOAL;

    public float m_attackFrameStart;

    //Status effects
    public bool m_SpeedDropped = false;
    public bool m_PermaSpeedDrop = false;
    public SpiderWeb m_CurrentWeb;

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
    public float m_PushTimer = 0.75f;
    public float m_PushImmunity = 5.0f;
    public bool m_PushImmune = false;

    public float m_chargeTimer = 0.5f;

    public ParticleSystem m_debuff;
    public ParticleSystem m_Particle;
    public ParticleSystem m_deathParticle;
    public VisualEffect m_deathEffect;
    [SerializeField] ParticleSystem.MainModule m_main;

    //Animation
    public Animator m_anim;

    public PlayerResourceManager m_resource;

    public WorldCharacter m_Player;

    public Transform m_Destination;

    public AudioSource m_Damage;

    public AudioSource m_Dead;

    public bool BossBool;

    public VisualEffect m_chargeParticle;
    public VisualEffect m_attackParticle;
    //Yep, they made some effects particles and some VFX
    //So I have to make 2 different particle systems for attack
    public ParticleSystem m_attackParticleSystem;

    //Enemies have one or the other
    //attackHbox refers to melee attackers
    //attackProj refers to ranged attackers
    public TDEnemyAttack m_attackHbox;
    public TDEnemyProjectile m_attackProj;
    public Transform m_projectileSpawn;
    public bool ranged;

    public float moneyMult;

    // Start is called before the first frame update
    public virtual void Start()
    {
        if (m_chargeParticle != null)
        {
            m_chargeParticle.enabled = false;
        }

        m_agent = GetComponent<NavMeshAgent>();
        m_agent.speed = m_moveSpeed;

        m_agent.destination = m_Destination.position;
        m_resource = FindObjectOfType<PlayerResourceManager>();

        m_Player = FindObjectOfType<WorldCharacter>();

        m_debuffMultiplier = 1.0f;

        aggressionTimer = maxAggressionTimer;

        m_main = m_Particle.main;

        if(m_deathEffect != null)
        {
            m_deathEffect.Stop();
        }

        if(m_attackParticle != null)
        {
            m_attackParticle.Stop();
        }

        if (m_attackParticleSystem != null)
        {
            m_attackParticleSystem.Stop();
        }

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

        if (m_debuffMultiplier != 1.0f && m_debuff.isStopped)
        {
            m_debuff.Play();
        }
        else if (m_debuffMultiplier == 1.0f)
        {
            m_debuff.Stop();
        }
    }

    public void PushControl()
    {
        if (m_Pushed && !m_PushImmune)
        {
            m_PushTimer -= Time.deltaTime;
            GetComponent<Rigidbody>().MovePosition(transform.position - (m_agent.velocity.normalized * 0.25f));

            if (m_PushTimer <= 0)
            {
                m_Pushed = false;
                m_PushImmune = true;
                m_PushTimer = 0.75f;
            }
        }

        if(m_PushImmune)
        {
            m_PushImmunity -= Time.deltaTime;
            if (m_PushImmunity <= 0)
            {
                m_PushImmunity = 5.0f;
                m_PushImmune = false;
            }
        }
    }

    public void Push()
    {
        if (!m_PushImmune)
        {
            m_Pushed = true;
        }
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
                    m_anim.SetBool("Run", false);
                    m_anim.SetBool("Charge", false);
                    if (m_chargeParticle != null)
                    {
                        m_chargeParticle.enabled = false;
                    }
                    if(m_attackParticle != null)
                    {
                        m_attackParticle.Stop();
                    }
                    if (m_attackParticleSystem != null)
                    {
                        m_attackParticleSystem.Stop();
                    }
                }
                if (m_attackHbox != null)
                {
                    m_attackHbox.m_cc.enabled = false;
                }
                m_agent.speed = m_moveSpeed;
                break;
            case TargetState.PLAYER:
                //Totally different code based on range and physical attacks
                //Would be a lot cleaner if the artists' VFX are all different components
                if (ranged)
                {
                    //Instead of moving, stand in place
                    m_agent.destination = transform.position;
                    if (m_anim != null)
                    {
                        if (m_anim.GetBool("Charge") && m_chargeTimer < 0.0f)
                        {
                            //The enemy attacks
                            //its stops the dash
                            //Returns to its usual speed
                            //and charge is removed
                            m_anim.SetTrigger("Attack");
                            if (m_attackProj != null)
                            {
                                TDEnemyProjectile g = Instantiate(m_attackProj, m_projectileSpawn.position, transform.rotation);
                                g.InheritFromEnemy(this);
                            }

                            if (m_attackParticle != null)
                            {
                                m_attackParticle.Play();
                            }
                            if (m_attackParticleSystem != null)
                            {
                                m_attackParticleSystem.Play();
                            }

                            m_anim.SetBool("Charge", false);
                            if (m_chargeParticle != null)
                            {
                                m_chargeParticle.enabled = false;
                            }
                        }
                        else if (m_anim.GetBool("Charge") && m_chargeTimer < 0.0f)
                        {
                            //The enemy finishes charging
                            //The enemy now starts running
                            //Speed increases
                            if (m_chargeParticle != null)
                            {
                                m_chargeParticle.enabled = false;
                            }
                        }
                        else if (m_anim.GetBool("Charge") && m_chargeTimer > 0.0f && m_anim.GetCurrentAnimatorStateInfo(1).IsName("Charge"))
                        {
                            //it is stationary, charging
                            //Timer till it can move decreases
                            transform.LookAt(m_Player.transform.position);
                            //Prevents any weird unwanted rotation
                            transform.rotation = new Quaternion(0, transform.rotation.y, 0, transform.rotation.w);
                            m_chargeTimer -= Time.deltaTime;
                        }
                        else
                        {
                            if (!m_anim.IsInTransition(1) && m_anim.GetCurrentAnimatorStateInfo(1).IsName("Default"))
                            {
                                //Starts charge
                                //Sets speed to 0
                                //Resets charge timer.

                                m_anim.SetBool("Charge", true);
                                if (m_chargeParticle != null)
                                {
                                    m_chargeParticle.enabled = true;
                                }

                                if (m_attackParticle != null)
                                {
                                    m_attackParticle.Stop();
                                }
                                if (m_attackParticleSystem != null)
                                {
                                    m_attackParticleSystem.Stop();
                                }

                                m_agent.speed = 0;
                                m_chargeTimer = 2.0f;
                            }
                        }

                    }
                }
                else
                {
                    m_agent.destination = m_Player.transform.position;

                    if (m_anim != null)
                    {
                        if (Vector3.Distance(transform.position, m_Player.transform.position) < 3.0f && m_anim.GetBool("Charge") && m_chargeTimer < 0.0f)
                        {
                            //The enemy attacks
                            //its stops the dash
                            //Returns to its usual speed
                            //and charge is removed
                            m_anim.SetTrigger("Attack");
                            if (m_attackHbox != null)
                            {
                                m_attackHbox.m_cc.enabled = true;
                            }
                            if (m_attackParticle != null)
                            {
                                m_attackParticle.Play();
                            }
                            if (m_attackParticleSystem != null)
                            {
                                m_attackParticleSystem.Play();
                            }
                            m_anim.SetBool("Run", false);
                            m_agent.speed = m_moveSpeed;
                            m_anim.SetBool("Charge", false);
                            if (m_chargeParticle != null)
                            {
                                m_chargeParticle.enabled = false;
                            }
                        }
                        else if (m_anim.GetBool("Charge") && m_chargeTimer < 0.0f)
                        {
                            //The enemy finishes charging
                            //The enemy now starts running
                            //Speed increases
                            m_anim.SetBool("Run", true);
                            m_agent.speed = m_moveSpeed * 2f;
                            if (m_chargeParticle != null)
                            {
                                m_chargeParticle.enabled = false;
                            }
                        }
                        else if (m_anim.GetBool("Charge") && m_chargeTimer > 0.0f && m_anim.GetCurrentAnimatorStateInfo(1).IsName("Charge"))
                        {
                            //it is stationary, charging
                            //Timer till it can move decreases
                            m_chargeTimer -= Time.deltaTime;
                        }
                        else
                        {
                            if (!m_anim.IsInTransition(1) && m_anim.GetCurrentAnimatorStateInfo(1).IsName("Default"))
                            {
                                //Starts charge
                                //Sets speed to 0
                                //Resets charge timer.
                                if (m_attackHbox != null)
                                {
                                    m_attackHbox.m_cc.enabled = false;
                                }

                                m_anim.SetBool("Charge", true);
                                if (m_chargeParticle != null)
                                {
                                    m_chargeParticle.enabled = true;
                                }

                                if (m_attackParticle != null)
                                {
                                    m_attackParticle.Stop();
                                }
                                if (m_attackParticleSystem != null)
                                {
                                    m_attackParticleSystem.Stop();
                                }

                                m_agent.speed = 0;
                                m_chargeTimer = 2.0f;
                            }
                        }

                    }
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
            } else
            {
                DOTDamage = 0;
                damageOverTime = false;
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
            m_agent.SetDestination(transform.position);
            GetComponent<CapsuleCollider>().enabled = false;
            if (!m_Dead.isPlaying)
            {
                if (m_CurrentWeb != null && m_CurrentWeb.Path3UG1)
                {
                    m_resource.AddMoney(100);
                }
                Destroy(gameObject);
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

            if(m_health <= 0)
            {
                m_Dead.Play();
            }
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

        if (val == 1.2f)
        {
            m_main.startColor = Color.green;
        }

        if(val == 0.8f)
        {
            m_main.startColor = Color.red;
        }

        if(val == 1.0f)
        {
            m_main.startColor = Color.gray;
        }
    }

    public bool CheckIfAttacking()
    {
        if (m_anim != null)
        {
            if (m_anim.GetCurrentAnimatorStateInfo(1).normalizedTime > (m_attackFrameStart / 40) && !m_anim.IsInTransition(1) && m_anim.GetCurrentAnimatorStateInfo(1).IsName("Attack"))
            {
                return true;
            }
        }

        return false;
    }
}
