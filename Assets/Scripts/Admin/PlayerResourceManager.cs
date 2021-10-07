using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerResourceManager : MonoBehaviour
{
    public float m_WorldHealth;
    public float m_Money;
    public SceneControl m_SceneControl;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(m_WorldHealth <= 0)
        {
            m_SceneControl.GameOver();
        }
    }

    public void AddMoney(float _money)
    {
        m_Money += _money;
    }

    public void SubMoney(float _money)
    {
        m_Money -= _money;
    }

    public void HealWorldHealth(float _recovery)
    {
        m_WorldHealth += _recovery;
    }

    public void DamageWorldHealth(float _damage)
    {
        m_WorldHealth -= _damage;
    }

}
