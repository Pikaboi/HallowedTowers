using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPurchase : MonoBehaviour
{
    public GameObject m_weaponMenuPrefab;
    public float m_price;
    public PlayerResourceManager m_resource;
    public InventoryAdd m_inventory;
    public TMPro.TMP_Text pricetag;

    public bool bought = false;

    public CreateWeaponUpgradeMenu m_UGmenuInstance;
    public ShopSpeechBubble m_textbubble;
    public AudioSource m_purchaseAudio;

    // Start is called before the first frame update
    void Start()
    {
        m_resource = FindObjectOfType<PlayerResourceManager>();
        pricetag.text += " " + m_price;

        if (bought)
        {
            pricetag.text = "SOLD OUT";
            GetComponent<UnityEngine.UI.Button>().enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnClick()
    {
        if (m_resource.m_Money >= m_price)
        {
            m_purchaseAudio.Play();
            m_textbubble.OnPurchase();
            bought = true;
            m_resource.SubMoney(m_price);
            //m_sound.Play();
            m_inventory.addWeapon(m_weaponMenuPrefab);

            pricetag.text = "SOLD OUT";
            GetComponent<UnityEngine.UI.Button>().enabled = false;

            //m_UGmenuInstance.UpdateEquips();
        }
    }
}
