using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TDTower_SpiderWeb : TDTower
{
    public Vector3 m_webPlacement = Vector3.zero;
    public GameObject m_sentry;
    public float m_sentryTime;
    public float m_sentryTimer;
    public Vector3 m_sentryPos = Vector3.zero;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        m_sentryTimer = m_sentryTime;
    }

    // Update is called once per frame
    public override void Update()
    {
        GetRandomPos();

        m_FireTimer -= Time.deltaTime;
        m_sentryTimer -= Time.deltaTime;

        if (m_FireTimer <= 0.0f)
        {
            if (m_webPlacement != Vector3.zero)
            {
                Instantiate(m_Projectile, m_webPlacement, transform.rotation);
                m_FireTimer = m_fireRate;
                m_webPlacement = Vector3.zero;
            }
        }

        if(m_sentryTimer <= 0.0f)
        {
            if(m_sentryPos != Vector3.zero)
            {
                GameObject sentry = Instantiate(m_sentry, m_sentryPos, transform.rotation);
                sentry.transform.localScale = new Vector3(20.0f, 20.0f, 20.0f);
                sentry.GetComponentInChildren<TDTower>().m_attack = m_attack / 3;
                m_sentryTimer = m_sentryTime;
                m_sentryPos = Vector3.zero;
            }
        }

    }

    public void GetRandomPos()
    {
        //Webs have to be on the navmesh
        if (m_webPlacement == Vector3.zero)
        {
            Vector3 randomPoint = transform.position + Random.insideUnitSphere * m_TriggerRange;
            randomPoint.y = 0;
            NavMeshHit hit;

            if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
            {
                m_webPlacement = hit.position;
            }
        }

        //Sentries cant be on the navmesh
        if(m_sentryPos == Vector3.zero)
        {
            Vector3 randomPoint = transform.position + Random.insideUnitSphere * m_TriggerRange;
            randomPoint.y = 0.0f;
            NavMeshHit hit;

            if (!NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
            {
                m_sentryPos = randomPoint;
            }
        }
    }
}
