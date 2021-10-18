using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TDTower_KrakenManager : MonoBehaviour
{
    TDTowerManager m_main;
    TDTower_Kraken m_kraken;
    public Vector3 aimpos;
    // Start is called before the first frame update
    void Start()
    {
        m_main = GetComponent<TDTowerManager>();
        m_kraken = m_main.m_child.GetComponent<TDTower_Kraken>();
    }

    // Update is called once per frame
    void Update()
    {
        m_kraken = m_main.m_child.GetComponent<TDTower_Kraken>();
        m_kraken.AimPos = aimpos;
    }
}
