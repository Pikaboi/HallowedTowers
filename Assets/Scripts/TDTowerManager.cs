using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TDTowerManager : MonoBehaviour
{
    GameObject m_child;
    public GameObject m_base;
    public GameObject m_upgrade1;
    public GameObject m_upgrade2;
    public GameObject m_upgrade1n2;

    bool m_UG2Bought = false;
    bool m_UG1Bought = false;

    public float m_cost;
    public float m_sellCost;

    // Start is called before the first frame update
    void Start()
    {
        m_child = Instantiate(m_base, transform.position, transform.rotation);
        m_child.transform.parent = gameObject.transform;

        m_sellCost = m_cost / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Upgrade1();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Upgrade2();
        }
    }

    void Upgrade1()
    {
        if(!m_UG2Bought)
        {
            Destroy(m_child);
            m_child = Instantiate(m_upgrade1, transform.position, transform.rotation);
            m_child.transform.parent = gameObject.transform;
            m_UG1Bought = true;
        } else
        {
            Destroy(m_child);
            m_child = Instantiate(m_upgrade1n2, transform.position, transform.rotation);
            m_child.transform.parent = gameObject.transform;
        }
    }

    void Upgrade2()
    {
        if (!m_UG1Bought)
        {
            Destroy(m_child);
            m_child = Instantiate(m_upgrade2, transform.position, transform.rotation);
            m_child.transform.parent = gameObject.transform;
            m_UG2Bought = true;
        }
        else
        {
            Destroy(m_child);
            m_child = Instantiate(m_upgrade1n2, transform.position, transform.rotation);
            m_child.transform.parent = gameObject.transform;
        }
    }
}
