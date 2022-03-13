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

    public float m_UGDiscount;
    public float m_LevelDiscount;
    public float m_AffinityDiscount;

    //Alternate designs for Upgrades
    public GameObject baseModel;
    public GameObject Path1Model;
    public GameObject Path2Model;
    public GameObject Path3Model;

    [SerializeField] public PlayerResourceManager m_resource;

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

        //I hope you like these if statements
        //Blame the dragon tower
        if (Path1Model != null)
        {
            Path1Model.SetActive(false);
        }

        if (Path2Model != null)
        {
            Path2Model.SetActive(false);
        }

        if (Path3Model != null)
        {
            Path3Model.SetActive(false);
        }
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

    public void ChangeModel(int _modelnum)
    {
        if(_modelnum == 0)
        {
            return;
        }

        baseModel.SetActive(false);

        if(_modelnum == 1)
        {
            Path1Model.SetActive(true);
        } else if (_modelnum == 2)
        {
            Path2Model.SetActive(true);
        } else if (_modelnum == 3)
        {
            Path3Model.SetActive(true);
        }   
    }
}
