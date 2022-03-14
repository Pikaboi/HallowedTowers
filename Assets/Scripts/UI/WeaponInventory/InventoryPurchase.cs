using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPurchase : MonoBehaviour
{
    public GameObject m_weaponMenuPrefab;
    public float m_price;
    public PlayerResourceManager m_resource;
    public InventoryAdd m_inventory;
    // Start is called before the first frame update
    void Start()
    {
        m_resource = FindObjectOfType<PlayerResourceManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        if (m_resource.m_Money >= m_price)
        {
            m_resource.SubMoney(m_price);
            //m_sound.Play();
            m_inventory.addWeapon(m_weaponMenuPrefab);
        }
    }
}
