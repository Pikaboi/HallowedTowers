using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Add the custom affinity namespace
using Affinity = affinity.Affinity;

public class Spikes : MonoBehaviour
{
    public float m_attack = 5;
    public Affinity m_affinity = Affinity.MONSTER;

    [SerializeField] private int m_Resistance;
    [SerializeField] bool m_Slow;
    [SerializeField] float m_cost;

    [SerializeField] PlayerResourceManager m_resource;

    //Upgrades
    //Path1 UG1 is the m_Slow Variable

    public bool Path1UG2;
    /// <summary>
    /// Make slow debuff stronger on affinity
    /// </summary>

    public bool Path1UG3;
    /// <summary>
    /// Make slowdown permanent
    /// </summary>

    public bool Path2UG1;
    /// <summary>
    /// Increase Affinity Advantage
    /// </summary>

    public bool Path2UG2;
    /// <summary>
    /// Increase Damage to monsters
    /// </summary>

    public bool Path2UG3;
    /// <summary>
    /// Reduce the reduction from a disadvantage
    /// </summary>

    //Path 3 UG 1 and 2 will modify the Durability

    public bool Path3UG3;
    /// <summary>
    /// Allow spikes to hit multiple enemies with one use
    /// </summary>

    // Start is called before the first frame update
    void Start()
    {

    }

    public void PayForSpikes()
    {
        m_resource = FindObjectOfType<PlayerResourceManager>();
        m_resource.SubMoney(m_cost);
    }

    // Update is called once per frame
    void Update()
    {
        if(m_Resistance <= 0)
        {
            Destroy(gameObject);
        }
    }

    //For road spikes
    public void SpikesDamage(TDEnemy _enemy)
    {
        m_resource.AddMoney(m_attack * AffinityCheck(_enemy.m_affinity) * _enemy.m_debuffMultiplier);
        _enemy.m_health -= m_attack * AffinityCheck(_enemy.m_affinity) * _enemy.m_debuffMultiplier;
        lowerResistance();
        _enemy.m_Damage.Play();

        if (m_Slow && !_enemy.m_SpeedDropped && !_enemy.m_PermaSpeedDrop)
        {
            if (Path1UG2)
            {
                float val = AffinityCheck(_enemy.m_affinity);
                if (val == 1.2f)
                {
                    _enemy.m_agent.speed = _enemy.m_agent.speed / 3;
                } else
                {
                    _enemy.m_agent.speed = _enemy.m_agent.speed / 2;
                }
            } else
            {
                _enemy.m_agent.speed = _enemy.m_agent.speed / 2;
            }

            if (Path1UG3)
            {
                _enemy.m_PermaSpeedDrop = true;
            }
            else
            {
                _enemy.m_SpeedDropped = true;
            }
        }
    }

    public float getCost()
    {
        return m_cost;
    }

    public void lowerResistance()
    {
        m_Resistance--;
    }

    public virtual float AffinityCheck(Affinity _affinity)
    {
        float multiplier = 1.0f;
        switch (_affinity)
        {
            case Affinity.MONSTER:
                //Neutral
                if (Path2UG2)
                {
                    multiplier = 1.2f;
                }
                else
                {
                    multiplier = 1.0f;
                }
                break;
            case Affinity.MAGIC:
                if (m_affinity == Affinity.UNDEAD)
                {
                    if (Path2UG1)
                    {
                        //Damage Decrease
                        multiplier = 1.5f;
                    } else
                    {
                        multiplier = 1.2f;
                    }
                }
                if (m_affinity == Affinity.SOUL)
                {
                    //Damage Increase
                    if (Path2UG3)
                    {
                        multiplier = 0.9f;
                    }
                    else
                    {
                        multiplier = 0.8f;
                    }
                }
                break;
            case Affinity.UNDEAD:
                if (m_affinity == Affinity.SOUL)
                {
                    if (Path2UG1)
                    {
                        //Damage Decrease
                        multiplier = 1.5f;
                    }
                    else
                    {
                        multiplier = 1.2f;
                    }
                }
                if (m_affinity == Affinity.MAGIC)
                {
                    //Damage Increase
                    if (Path2UG3)
                    {
                        multiplier = 0.9f;
                    }
                    else
                    {
                        multiplier = 0.8f;
                    }
                }
                break;
            case Affinity.SOUL:
                if (m_affinity == Affinity.MAGIC)
                {
                    if (Path2UG1)
                    {
                        //Damage Decrease
                        multiplier = 1.5f;
                    }
                    else
                    {
                        multiplier = 1.2f;
                    }
                }
                if (m_affinity == Affinity.UNDEAD)
                {
                    //Damage Increase
                    if (Path2UG3)
                    {
                        multiplier = 0.9f;
                    }
                    else
                    {
                        multiplier = 0.8f;
                    }
                }
                break;
            default:
                multiplier = 1.0f;
                break;
        }
        return multiplier;
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            SpikesDamage(other.gameObject.GetComponent<TDEnemy>());

            if (Path3UG3)
            {
                Collider[] c = Physics.OverlapSphere(transform.position, 1);

                int count = 0;

                foreach(Collider col in c)
                {
                    if(col.gameObject.GetComponent<TDEnemy>() != null)
                    {
                        SpikesDamage(col.gameObject.GetComponent<TDEnemy>());
                        count++;
                    }

                    if(count == 2)
                    {
                        break;
                    }
                }

            }
        }
    }
}
