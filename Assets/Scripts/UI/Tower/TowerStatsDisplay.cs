using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerStatsDisplay : MonoBehaviour
{
    TDTowerManager m_manager;
    public TMPro.TMP_Text atk;
    public TMPro.TMP_Text spd;
    public TMPro.TMP_Text range;
    // Start is called before the first frame update
    void Start()
    {
        m_manager = GetComponentInParent<TDTowerManager>();
    }

    // Update is called once per frame
    void Update()
    {
        atk.text = m_manager.m_child.GetComponent<TDTower>().m_attack.ToString();
        spd.text = m_manager.m_child.GetComponent<TDTower>().m_fireRate.ToString(); 
        range.text = m_manager.m_child.GetComponent<TDTower>().m_TriggerRange.ToString();
    }
}
