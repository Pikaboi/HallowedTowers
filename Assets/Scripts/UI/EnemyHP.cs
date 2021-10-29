using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHP : MonoBehaviour
{
    public Slider m_HPBar;
    public Image m_AggroNotif;
    public TDEnemy m_base;
    // Start is called before the first frame update
    void Start()
    {
        m_HPBar.maxValue = m_base.m_health;
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(45.0f, 0.0f, 0.0f);

        m_AggroNotif.enabled = m_base.aggro;
        m_HPBar.value = m_base.m_health;
    }
}
