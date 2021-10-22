using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TDTower_SpiderWeb : TDTower
{
    public Vector3 m_webPlacement = Vector3.zero;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        GetRandomPos();

        m_FireTimer -= Time.deltaTime;

        if (m_FireTimer <= 0.0f)
        {
            if (m_webPlacement != Vector3.zero)
            {
                Instantiate(m_Projectile, m_webPlacement, transform.rotation);
                m_FireTimer = m_fireRate;
                m_webPlacement = Vector3.zero;
            }
        }
    }

    public void GetRandomPos()
    {
        if(m_webPlacement == Vector3.zero)
        {
            Vector3 randomPoint = transform.position + Random.insideUnitSphere * m_TriggerRange;
            NavMeshHit hit;

            if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
            {
                m_webPlacement = hit.position;
            }
        }
    }
}
