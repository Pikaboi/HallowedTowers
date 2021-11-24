using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Add the custom affinity namespace
using Affinity =  affinity.Affinity;

public class TDTowerManager : MonoBehaviour
{
    public GameObject m_child;
    public Affinity m_affinity = Affinity.MONSTER;
    public GameObject m_base;

    public string m_towerName;

    public float m_cost;
    public float m_sellCost;

    public GameObject m_UpgradeUI;

    public float m_TriggerRange;
    public float m_fireRate;
    public float m_attack;
    public int m_level;

    public ParticleSystem m_UGParticle;
    public ParticleSystem m_BuffParticle;

    public ParticleSystem m_ShootParticle;

    [SerializeField] PlayerResourceManager m_resource;

    // Start is called before the first frame update
    void Start()
    {
        m_child = null;
        m_child = Instantiate(m_base, transform.position, transform.rotation);
        m_child.transform.parent = gameObject.transform;
        m_resource = FindObjectOfType<PlayerResourceManager>();
        m_sellCost = m_cost / 2;
        m_UpgradeUI.SetActive(false);
        m_UGParticle.Play();
    }

    // Update is called once per frame
    void Update()
    {
        m_child.GetComponent<TDTower>().SetAffinity(m_affinity);
        CopyStats();
        if (m_child.GetComponent<TDTower>().m_atkBuff != 0 && m_BuffParticle.isStopped)
        {
            m_BuffParticle.Play();
        } else if(m_child.GetComponent<TDTower>().m_atkBuff == 0)
        {
            m_BuffParticle.Stop();
        }
    }

    public void newUpgrade(GameObject _upgradePrefab)
    {
        Destroy(m_child);
        m_child = Instantiate(_upgradePrefab, transform.position, transform.rotation);
        m_child.transform.parent = gameObject.transform;
        PassStats();
        m_UGParticle.Play();
    }

    public void showRange()
    {
        m_child.GetComponent<TDTower>().ShowViewer();
        m_UpgradeUI.SetActive(true);
    }

    public void hideRange()
    {
        m_child.GetComponent<TDTower>().HideViewer();
        m_UpgradeUI.SetActive(false);
    }

    public void CopyStats()
    {
        m_attack = m_child.GetComponent<TDTower>().m_attack;
        m_fireRate = m_child.GetComponent<TDTower>().m_fireRate;
        m_TriggerRange = m_child.GetComponent<TDTower>().m_TriggerRange;
        m_level = m_child.GetComponent<TDTower>().m_level;
    }

    public void PassStats()
    {
        m_child.GetComponent<TDTower>().m_attack = m_attack;
        m_child.GetComponent<TDTower>().m_fireRate = m_fireRate;
        m_child.GetComponent<TDTower>().m_TriggerRange = m_TriggerRange;
        m_child.GetComponent<TDTower>().m_level = m_level;
    }
}
