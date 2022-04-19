using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TDTowerUpgrade_Path : TDTowerUpgrade
{
    public TDTowerUpgrade_Path[] m_UGPaths;
    public int PathNum;

    public string resourcePath;
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        m_UGPrefab = Resources.Load<GameObject>("Towers/" + resourcePath);
    }

    public override void PurchaseUpgrade()
    {
        if (m_resource.m_Money >= m_UGCost)
        {
            
            m_manager.newUpgrade(m_UGPrefab);
            m_UGBought = true;
            GetComponent<Image>().sprite = m_Purchased;
            m_resource.SubMoney(m_UGCost);
            m_manager.m_sellCost += m_UGCost / 2;

            m_manager.ChangeModel(PathNum);

            //Take out all the starting upgrade paths
            //Only one path, no crosspaths
            foreach (TDTowerUpgrade_Path t in m_UGPaths)
            {
                if (t != this)
                {
                    t.gameObject.GetComponent<Button>().enabled = false;
                    t.gameObject.GetComponent<Image>().sprite = t.gameObject.GetComponent<TDTowerUpgrade>().m_Locked;
                    t.gameObject.GetComponent<TDTowerUpgrade>().m_successor.GetComponent<Image>().sprite = m_Locked;
                    t.gameObject.GetComponent<TDTowerUpgrade>().m_successor.m_successor.GetComponent<Image>().sprite = m_Locked;
                }
            }

            GetComponent<Button>().enabled = false;
            m_sound.Play();

            if (m_successor != null)
            {
                m_successor.gameObject.GetComponent<Button>().enabled = true;
            }
        }
    }
}
