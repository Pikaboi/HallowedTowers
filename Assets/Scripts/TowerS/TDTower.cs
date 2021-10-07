using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Add the custom affinity namespace
using Affinity = affinity.Affinity;
public class TDTower : MonoBehaviour
{
    //Values all towers will share
    public SphereCollider m_Trigger;
    public float m_TriggerRange;
    //the projectile doesnt need to be a attacking type, can be anything
    //So I will set it up as a GameObject
    public GameObject m_Projectile;
    public float m_fireRate;
    public float m_attack;
    public GameObject m_aimer;
    public bool m_InRange;
    public GameObject m_RadiusViewer;
    public Affinity m_Affinity;

    [SerializeField] PlayerResourceManager m_resource;

    public float m_FireTimer;

    // Start is called before the first frame update
    public virtual void Start()
    {
        m_Trigger = GetComponent<SphereCollider>();
        m_Trigger.radius = m_TriggerRange;
        m_FireTimer = m_fireRate;

        m_resource = FindObjectOfType<PlayerResourceManager>();

        if (m_RadiusViewer != null)
        {
            m_RadiusViewer.SetActive(false);
        }
    }

    // Update is called once per frame
    public virtual void Update()
    {
        CheckEnemies();
        Aim();
        if (m_InRange)
        {
            m_FireTimer -= Time.deltaTime;
            
            if(m_FireTimer <= 0.0f)
            {
                GameObject bullet = Instantiate(m_Projectile, transform.position + transform.forward * 1.5f, m_aimer.transform.rotation);
                bullet.GetComponent<TDProjectile>().InheritFromTower(m_TriggerRange, m_attack, gameObject, m_Affinity);
                m_FireTimer = m_fireRate;
            }
        }

        //To get sub towers like Reapers Scythe updated
        TDTower[] childTowers = gameObject.GetComponentsInChildren<TDTower>();

        if(childTowers.Length > 0)
        {
            for(int i = 0; i < childTowers.Length; i++)
            {
                Debug.Log(childTowers[i]);
                childTowers[i].SetAffinity(m_Affinity);
            }
        }

    }

    public virtual void CheckEnemies()
    {
        Collider[] ObjsInRange = Physics.OverlapSphere(transform.position, m_TriggerRange);

        bool range = false;

        foreach (Collider Obj in ObjsInRange)
        {
            if (Obj.gameObject.tag == "Enemy")
            {
                range = true;
            }
        }
        m_InRange = range;
    }

    public virtual void Aim()
    {
        Collider[] ObjsInRange = Physics.OverlapSphere(transform.position, m_TriggerRange);

        foreach(Collider Obj in ObjsInRange)
        {
            if(Obj.gameObject.GetComponent<TDEnemy>() != null)
            {
                Vector3 lookat = Obj.gameObject.transform.position - transform.position;
                lookat.y = 0;
                Quaternion Rotation = Quaternion.LookRotation(lookat);
                transform.rotation = Quaternion.Slerp(transform.rotation, Rotation, 1);

                m_aimer.transform.LookAt(Obj.gameObject.transform.position);
            }
        }
    }

    public void ShowViewer()
    {
        m_RadiusViewer.SetActive(true);
    }

    public void HideViewer()
    {
        m_RadiusViewer.SetActive(false);
    }

    public void SetAffinity(Affinity affinity)
    {
        m_Affinity = affinity;
    }
}
