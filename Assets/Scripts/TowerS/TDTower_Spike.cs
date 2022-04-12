using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TDTower_Spike : TDTower
{
    [SerializeField] Spikes m_Spikes;

    public List<Spikes> m_activeSpikes = new List<Spikes>();

    Vector3 spikePos = Vector3.zero;
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        m_FireTimer = 0;
    }

    // Update is called once per frame
    //Generally the same as the base tower, however we will spawn a spike instead of a bullet
    public override void Update()
    {
        GetSpikePosition();

        m_FireTimer -= Time.deltaTime;

        if (m_FireTimer <= 0.0f && m_activeSpikes.Count < 5)
        {
            if (spikePos != Vector3.zero)
            {
                Spikes s = Instantiate(m_Spikes, spikePos, transform.rotation);
                s.m_affinity = m_Affinity;
                m_FireTimer = m_fireRate - (m_fireRate * m_fireRateBuff);
                spikePos = Vector3.zero;
                m_activeSpikes.Add(s);
            }
        }

        if (m_activeSpikes.Count >= 5)
        {
            foreach(Spikes s in m_activeSpikes)
            {
                if(s == null)
                {
                    m_activeSpikes.Remove(s);
                }
            }
        }

    }

    public void GetSpikePosition()
    {
        //Webs have to be on the navmesh
        if (spikePos == Vector3.zero)
        {
            Vector3 randomPoint = transform.position + Random.insideUnitSphere * m_TriggerRange;
            randomPoint.y = 0;
            NavMeshHit hit;

            if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
            {
                spikePos = hit.position;
            }
        }
    }
}
