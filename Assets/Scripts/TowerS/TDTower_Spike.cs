using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TDTower_Spike : TDTower
{
    [SerializeField] Spikes m_Spikes;
 
    Vector3 enemypos;

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
        CheckEnemies();
        Aim();
        if (m_InRange)
        {
            m_FireTimer -= Time.deltaTime;

            if (m_FireTimer <= 0.0f)
            {
                Spikes s = Instantiate(m_Spikes, enemypos - new Vector3(0.0f, 1.0f, 0.0f), transform.rotation);
                s.m_affinity = m_Affinity;
                s.m_attack = m_attack;
                m_FireTimer = m_fireRate;
            }
        }
    }

    public override void CheckEnemies()
    {
        Collider[] ObjsInRange = Physics.OverlapSphere(transform.position, m_TriggerRange);

        bool range = false;

        foreach (Collider Obj in ObjsInRange)
        {
            if (Obj.gameObject.tag == "Enemy")
            {
                range = true;
                enemypos = Obj.gameObject.transform.position;
            }
        }
        m_InRange = range;
    }
}
