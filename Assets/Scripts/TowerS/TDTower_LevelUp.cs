using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TDTower_LevelUp : MonoBehaviour
{
    TDTower m_tower;
    [SerializeField] float m_UpgradePrice;
    PlayerResourceManager m_resource;

    public AudioSource m_sound;

    public bool isMax;

    // Start is called before the first frame update
    void Start()
    {
        //m_tower = gameObject.GetComponentInParent<TDTowerManager>().m_child.GetComponent<TDTower>();
        m_resource = FindObjectOfType<PlayerResourceManager>();
        m_UpgradePrice = gameObject.GetComponentInParent<TDTowerManager>().m_cost;
    }

    // Update is called once per frame
    void Update()
    {
        m_tower = gameObject.GetComponentInParent<TDTowerManager>().m_child.GetComponent<TDTower>();
        m_resource = FindObjectOfType<PlayerResourceManager>();
    }

    public void LevelUp()
    {
        if(m_resource.m_Money >= m_UpgradePrice && m_tower.m_level < 20)
        {
            m_resource.SubMoney(m_UpgradePrice);
            gameObject.GetComponentInParent<TDTowerManager>().m_sellCost += m_UpgradePrice / 2;
            m_UpgradePrice = Mathf.Round(m_UpgradePrice * 1.2f);
            m_tower.levelUp();
            gameObject.GetComponentInParent<TDTowerManager>().m_UGParticle.Play();
            m_sound.Play();
        }

        if(m_tower.m_level == 20)
        {
            isMax = true;
        }
    }

    public float GetPrice()
    {
        return m_UpgradePrice;
    }
}
