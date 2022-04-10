using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerNameTag : MonoBehaviour
{
    [SerializeField] private TMPro.TMP_Text t;
    [SerializeField] TDTowerManager m_manager;
    [SerializeField] private TMPro.TMP_FontAsset m_font;
    // Start is called before the first frame update
    void Start()
    {
        t = gameObject.GetComponent<TMPro.TMP_Text>();
        t.font = m_font;
        m_manager = gameObject.GetComponentInParent<TDTowerManager>();
    }

    // Update is called once per frame
    void Update()
    {
        t.font = m_font;
        t.text = m_manager.m_towerName;
    }
}
