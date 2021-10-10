using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TDTower_LevelUp : MonoBehaviour
{
    TDTower m_tower;
    [SerializeField] float m_UpgradePrice;
    PlayerResourceManager m_resource;

    // Start is called before the first frame update
    void Start()
    {
        m_tower = gameObject.GetComponentInParent<TDTowerManager>().m_child.GetComponent<TDTower>();
        m_resource = FindObjectOfType<PlayerResourceManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LevelUp()
    {
        if(m_resource.m_Money >= m_UpgradePrice)
        {
            m_resource.SubMoney(m_UpgradePrice);
            gameObject.GetComponentInParent<TDTowerManager>().m_sellCost += m_UpgradePrice / 2;
            m_UpgradePrice *= 2;
            m_tower.levelUp();
        }
    }
}
