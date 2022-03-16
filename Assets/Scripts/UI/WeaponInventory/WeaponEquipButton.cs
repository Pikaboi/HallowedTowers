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
    public TMPro.TMP_Text attackt;

    float UpgradePrice = 0;
    int UGCount = 1;
    public float attackBoost;

    PlayerResourceManager m_resource;

    public UnityEngine.UI.Image m_affinitySprite;

    /*void Start()
    {
        UpgradePrice = m_Weapon.GetComponent<PlayerWeapon>().m_Attack * 1000;
        m_Player = FindObjectOfType<WorldCharacter>();
        t = GetComponentInChildren<TMPro.TMP_Text>();
        GetComponent<UnityEngine.UI.Image>().alphaHitTestMinimumThreshold = 1.0f;
        m_resource = FindObjectOfType<PlayerResourceManager>();
    }*/

    private void Awake()
    {
        if (m_Weapon != null)
        {
            UpgradePrice = m_Weapon.GetComponent<PlayerWeapon>().m_Attack * 1000;
        }
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
            if (m_Weapon != null)
            {
                t.text = m_Weapon.name;
            } else
            {
                t.text = "";
            }
        }

        if (attackt != null)
        {
            attackt.text = "Attack: " + (m_Weapon.GetComponent<PlayerWeapon>().m_Attack + attackBoost);
        }
    }

    // Update is called once per frame
    public void OnClick()
    {
        if (m_Weapon != null)
        {
            m_Player.SpawnWeapon(m_Weapon, m_rot, attackBoost);
        }
    }

    public void Upgrade()
    {
        if (m_Weapon != null)
        {
            if (m_resource.m_Money >= UpgradePrice && UGCount < 5)
            {
                m_resource.SubMoney(UpgradePrice);
                if (UGCount == 1)
                {
                    attackBoost = m_Weapon.GetComponent<PlayerWeapon>().m_Attack;
                }
                else
                {
                    attackBoost = (attackBoost) * 2;
                }
                UGCount++;
                UpgradePrice = (attackBoost) * 1000;

                attackt.text = "Attack: " + (m_Weapon.GetComponent<PlayerWeapon>().m_Attack + attackBoost);
            }
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
