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

    [SerializeField] PlayerResourceManager m_resource;

    // Start is called before the first frame update
    void Start()
    {
        m_child = Instantiate(m_base, transform.position, transform.rotation);
        m_child.transform.parent = gameObject.transform;
        m_resource = FindObjectOfType<PlayerResourceManager>();
        m_sellCost = m_cost / 2;
        m_UpgradeUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        m_child.GetComponent<TDTower>().SetAffinity(m_affinity);
    }

    public void newUpgrade(GameObject _upgradePrefab)
    {
        Destroy(m_child);
        m_child = Instantiate(_upgradePrefab, transform.position, transform.rotation);
        m_child.transform.parent = gameObject.transform;
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
}
