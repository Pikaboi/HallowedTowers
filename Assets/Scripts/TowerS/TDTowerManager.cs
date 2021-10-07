using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Add the custom affinity namespace
using Affinity =  affinity.Affinity;

public class TDTowerManager : MonoBehaviour
{
    GameObject m_child;
    public Affinity m_affinity = Affinity.MONSTER;
    public GameObject m_base;
    public GameObject m_upgrade1;
    public GameObject m_upgrade2;
    public GameObject m_upgrade1n2;

    public string m_UG1String;
    public string m_UG2String;

    public bool m_UG2Bought = false;
    public bool m_UG1Bought = false;

    public float m_cost;
    public float m_sellCost;

    public float m_UG1Cost;
    public float m_UG2Cost;

    [SerializeField] PlayerResourceManager m_resource;

    // Start is called before the first frame update
    void Start()
    {
        m_child = Instantiate(m_base, transform.position, transform.rotation);
        m_child.transform.parent = gameObject.transform;
        m_resource = FindObjectOfType<PlayerResourceManager>();
        m_sellCost = m_cost / 2;
    }

    // Update is called once per frame
    void Update()
    {
        m_child.GetComponent<TDTower>().SetAffinity(m_affinity);
    }

    public void Upgrade1()
    {
        if (!m_UG1Bought)
        {
            if (!m_UG2Bought)
            {
                if (m_resource.m_Money >= m_UG1Cost)
                {
                    Destroy(m_child);
                    m_child = Instantiate(m_upgrade1, transform.position, transform.rotation);
                    m_child.transform.parent = gameObject.transform;
                    m_UG1Bought = true;
                    m_resource.SubMoney(m_UG1Cost);
                    m_sellCost += m_UG1Cost / 2;
                }
            }
            else
            {
                if (m_resource.m_Money >= m_UG1Cost)
                {
                    Destroy(m_child);
                    m_child = Instantiate(m_upgrade1n2, transform.position, transform.rotation);
                    m_child.transform.parent = gameObject.transform;
                    m_UG1Bought = true;
                    m_resource.SubMoney(m_UG1Cost);
                    m_sellCost += m_UG1Cost / 2;
                }
            }
        }
    }

    public void Upgrade2()
    {
        if (!m_UG2Bought)
        {
            if (!m_UG1Bought)
            {
                if (m_resource.m_Money >= m_UG2Cost)
                {
                    Destroy(m_child);
                    m_child = Instantiate(m_upgrade2, transform.position, transform.rotation);
                    m_child.transform.parent = gameObject.transform;
                    m_UG2Bought = true;
                    m_resource.SubMoney(m_UG2Cost);
                    m_sellCost += m_UG2Cost / 2;
                }
            }
            else
            {
                if (m_resource.m_Money >= m_UG2Cost)
                {
                    Destroy(m_child);
                    m_child = Instantiate(m_upgrade1n2, transform.position, transform.rotation);
                    m_child.transform.parent = gameObject.transform;
                    m_UG2Bought = true;
                    m_resource.SubMoney(m_UG2Cost);
                    m_sellCost += m_UG2Cost / 2;
                }
            }
        }
    }

    public void showRange()
    {
        m_child.GetComponent<TDTower>().ShowViewer();
    }

    public void hideRange()
    {
        m_child.GetComponent<TDTower>().HideViewer();
    }
}
