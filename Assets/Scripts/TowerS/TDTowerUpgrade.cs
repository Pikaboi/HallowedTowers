using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TDTowerUpgrade : MonoBehaviour
{
    public string m_UGString;
    public bool m_UGBought = false;
    public TDTowerUpgrade m_successor;
    public float m_UGCost;

    public TMPro.TMP_Text m_UGName;
    public TMPro.TMP_Text m_UGCostString;

    public GameObject m_UGPrefab;

    public PlayerResourceManager m_resource;
    public TDTowerManager m_manager;

    // Start is called before the first frame update
    public void Start()
    {
        m_manager = GetComponentInParent<TDTowerManager>();
        m_resource = FindObjectOfType<PlayerResourceManager>();
    }

    // Update is called once per frame
    public void Update()
    {
        m_UGName.text = m_UGString;
        m_UGCostString.text = m_UGCost.ToString();
    }

    public void PurchaseUpgrade()
    {
        if (m_resource.m_Money >= m_UGCost)
        {
            m_manager.newUpgrade(m_UGPrefab);
            m_UGBought = true;
            m_resource.SubMoney(m_UGCost);
            m_manager.m_sellCost += m_UGCost / 2;
        }
    }
}
