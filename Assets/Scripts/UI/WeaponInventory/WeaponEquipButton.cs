using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponEquipButton : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject m_Weapon;
    public WorldCharacter m_Player;
    public Vector3 m_rot;
    public TMPro.TMP_Text t;

    float UpgradePrice = 0;
    int UGCount = 1;
    public float attackBoost;

    PlayerResourceManager m_resource;

    void Start()
    {
        UpgradePrice = m_Weapon.GetComponent<PlayerWeapon>().m_Attack * 1000;
        m_Player = FindObjectOfType<WorldCharacter>();
        t = GetComponentInChildren<TMPro.TMP_Text>();
        GetComponent<UnityEngine.UI.Image>().alphaHitTestMinimumThreshold = 1.0f;
        m_resource = FindObjectOfType<PlayerResourceManager>();
    }

    private void Update()
    {
        if (gameObject.tag == "InventoryEquip")
        {
            t.text = "Equip";
        }
        else
        {
            t.text = m_Weapon.name;
        }
    }

    // Update is called once per frame
    public void OnClick()
    {
        m_Player.SpawnWeapon(m_Weapon, m_rot, attackBoost);
    }

    public void Upgrade()
    {
        if (m_resource.m_Money >= UpgradePrice && UGCount < 5)
        {
            m_resource.SubMoney(UpgradePrice);
            if(UGCount == 1)
            {
                attackBoost = m_Weapon.GetComponent<PlayerWeapon>().m_Attack;
            } else
            {
                attackBoost = (attackBoost) * 2;
            }
            UGCount++;
            UpgradePrice = (attackBoost) * 1000;
        }
    }

    public int GetUGCount()
    {
        return UGCount;
    }

    public float GetUGPrice()
    {
        return UpgradePrice;
    }
}
