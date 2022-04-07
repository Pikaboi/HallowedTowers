using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Add the custom affinity namespace
using Affinity = affinity.Affinity;

public class ChangeAffinity : MonoBehaviour
{
    [SerializeField] Affinity m_affinity;
    [SerializeField] TDTowerManager m_manager;

    [SerializeField] AffinityPriceTag m_PriceTag;

    PlayerResourceManager m_resource;
    public float m_upgradePrice;
    public float m_baseCost;

    public AudioSource m_Sound;

    // Start is called before the first frame update
    void Start()
    {
        m_manager = gameObject.GetComponentInParent<TDTowerManager>();
        m_resource = FindObjectOfType<PlayerResourceManager>();
        m_baseCost = m_upgradePrice;
    }

    public virtual void Awake()
    {
        m_resource = FindObjectOfType<PlayerResourceManager>();
    }

    // Update is called once per frame
    void Update()
    {
        m_upgradePrice = m_baseCost - (m_baseCost * m_manager.m_AffinityDiscount);
    }

    public void SetAffinity()
    {
        if (m_resource.m_Money >= m_upgradePrice)
        {
            m_manager.m_affinity = m_affinity;
            m_resource.SubMoney(m_upgradePrice);
            m_PriceTag.UpdatePrice();
            m_manager.m_UGParticle.Play();
            m_Sound.Play();
        }
    }
}
