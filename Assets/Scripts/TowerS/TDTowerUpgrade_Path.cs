using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TDTowerUpgrade_Path : TDTowerUpgrade
{
    public TDTowerUpgrade_Path[] m_UGPaths;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
    }

    public override void PurchaseUpgrade()
    {
        if (m_resource.m_Money >= m_UGCost)
        {
            m_manager.newUpgrade(m_UGPrefab);
            m_UGBought = true;
            m_resource.SubMoney(m_UGCost);
            m_manager.m_sellCost += m_UGCost / 2;

            //Take out all the starting upgrade paths
            //Only one path, no crosspaths
            foreach (TDTowerUpgrade_Path t in m_UGPaths)
            {
                t.gameObject.GetComponent<UnityEngine.UI.Button>().enabled = false;
            }

            if (m_successor != null)
            {
                m_successor.gameObject.GetComponent<UnityEngine.UI.Button>().enabled = true;
            }
        }
    }
}
