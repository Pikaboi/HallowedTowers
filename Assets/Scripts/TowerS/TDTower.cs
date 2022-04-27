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
    public int m_level = 1;
    //the projectile doesnt need to be a attacking type, can be anything
    //So I will set it up as a GameObject
    public GameObject m_Projectile;
    public float m_fireRate;
    public float m_fireRateBuff;
    public float m_attack;
    public float m_atkBuff;
    public GameObject m_aimer;
    public bool m_InRange;
    public GameObject m_RadiusViewer;
    public Affinity m_Affinity;

    public Vector3 rotaterLookAt;

    [SerializeField] PlayerResourceManager m_resource;

    public float m_FireTimer;

    public string resourceString;

    // Start is called before the first frame update
    public virtual void Start()
    {
        m_Projectile = Resources.Load<GameObject>("Projectiles/" + resourceString);

        m_Trigger = GetComponent<SphereCollider>();
        m_Trigger.radius = m_TriggerRange;
        m_FireTimer = m_fireRate;

        m_RadiusViewer.transform.localScale = new Vector3(m_TriggerRange * 2, m_RadiusViewer.transform.localScale.y, m_TriggerRange * 2);

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
                bullet.GetComponent<TDProjectile>().InheritFromTower(m_TriggerRange, m_attack + (m_attack * m_atkBuff), gameObject, m_Affinity);
                m_FireTimer = m_fireRate - (m_fireRate * m_fireRateBuff);

                if(GetComponentInParent<TDTowerManager>().m_ShootParticle != null)
                {
                    GetComponentInParent<TDTowerManager>().m_ShootParticle.Play();
                }
            }
        }

        //To get sub towers like Reapers Scythe updated
        TDTower[] childTowers = gameObject.GetComponentsInChildren<TDTower>();

        if(childTowers.Length > 0)
        {
            for(int i = 0; i < childTowers.Length; i++)
            {
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
                rotaterLookAt = lookat;
                Quaternion Rotation = Quaternion.LookRotation(lookat);
                transform.rotation = Quaternion.Slerp(transform.rotation, Rotation, 1);

                m_aimer.transform.LookAt(Obj.gameObject.transform.position);
            }
        }
    }

    public virtual void levelUp()
    {
        if (m_level < 20)
        {
            m_attack += 1;
            m_level++;
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

    public void Buff(float buffMult, float fireRate)
    {
        if (buffMult > m_atkBuff)
        {
            m_atkBuff = buffMult;
        }

        if (fireRate > m_fireRateBuff)
        {
            m_fireRateBuff = fireRate;
        }
    }

    public void Debuff()
    {
        m_atkBuff = 0;
    }
}
