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

    public void lowerResistance()
    {
        m_Resistance--;
    }

    public bool getSlow()
    {
        return m_Slow;
    }

    public float getCost()
    {
        return m_cost;
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<TDEnemy>().SpikesDamage(this);
        }
    }
}
