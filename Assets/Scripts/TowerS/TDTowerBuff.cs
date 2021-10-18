using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TDTowerBuff : MonoBehaviour
{
    TDTower m_base;
    public float m_multiplier = 1;
    public float m_AtkBonus = 1;
    // Start is called before the first frame update
    void Start()
    {
        m_base = gameObject.GetComponent<TDTower>();
    }

    void Buff(float multiplier)
    {
        m_multiplier += multiplier;

        m_AtkBonus = m_base.m_attack * multiplier;
    }

    void UnBuff(float multiplier)
    {
        m_multiplier -= multiplier;

        m_AtkBonus = m_base.m_attack = multiplier;
    }
}
