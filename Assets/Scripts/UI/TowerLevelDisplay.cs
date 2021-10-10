using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerLevelDisplay : MonoBehaviour
{
    TDTowerManager m_manager;
    TMPro.TMP_Text t;
    // Start is called before the first frame update
    void Start()
    {
        m_manager = GetComponentInParent<TDTowerManager>();
        t = GetComponent<TMPro.TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        t.text = m_manager.m_child.GetComponent<TDTower>().m_level.ToString();
    }
}
