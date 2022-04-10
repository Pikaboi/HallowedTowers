using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerNameTag : MonoBehaviour
{
    [SerializeField] private TMPro.TMP_Text t;
    [SerializeField] TDTowerManager m_manager;
    // Start is called before the first frame update
    void Start()
    {
        t = gameObject.GetComponent<TMPro.TMP_Text>();
        m_manager = gameObject.GetComponentInParent<TDTowerManager>();
    }

    // Update is called once per frame
    void Update()
    {
        t.text = m_manager.m_towerName;
    }
}
