using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TDTower_Spike : TDTower
{
    [SerializeField] Spikes m_Spikes;

    GameObject NavMesh;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();

        Collider[] cols = Physics.OverlapSphere(transform.position, m_TriggerRange);

        foreach(Collider c in cols)
        {
            if(c.gameObject.layer == 13)
            {
                NavMesh = c.gameObject;
            }
        }
    }

    // Update is called once per frame
    //Generally the same as the base tower, however we will spawn a spike instead of a bullet
    public override void Update()
    {
        m_FireTimer -= Time.deltaTime;

        if (m_FireTimer <= 0.0f)
        {
            Instantiate(m_Spikes, GetSpawnLocation(), transform.rotation);
            m_FireTimer = m_fireRate;
        }
    }

    private Vector3 GetSpawnLocation()
    {
        Vector3 spawn = new Vector3(Random.Range(transform.position.x - m_TriggerRange, transform.position.x + m_TriggerRange), 
            transform.position.y, 
            Random.Range(transform.position.z - m_TriggerRange, transform.position.z + m_TriggerRange));

       

        return spawn;
    }
}
