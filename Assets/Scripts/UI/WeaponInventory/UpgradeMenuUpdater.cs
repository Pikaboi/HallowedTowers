using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeMenuUpdater : MonoBehaviour
{
    // Start is called before the first frame update
    public Image m_AffImage1;
    public Image m_AffImage2;
    public TMPro.TMP_Text m_WeaponName;
    public TMPro.TMP_Text m_Cost;
    public TMPro.TMP_Text m_CurrentStats;
    public TMPro.TMP_Text m_NewStats;

    public WeaponEquipButton m_equip;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(m_equip != null)
        {
            if (m_equip.GetUGCount() == 5)
            {
                m_WeaponName.text = m_equip.m_Weapon.name + " Level MAX";
            }
            else
            {
                m_WeaponName.text = m_equip.m_Weapon.name + " Level " + m_equip.GetUGCount().ToString();
            }

            m_CurrentStats.text = "Attack: " + (m_equip.m_Weapon.GetComponent<PlayerWeapon>().m_Attack + m_equip.attackBoost).ToString();

            if(m_equip.GetUGCount() == 5)
            {
                m_NewStats.text = m_CurrentStats.text;
            }
            else
            {
                m_NewStats.text = "Attack: " + (m_equip.m_Weapon.GetComponent<PlayerWeapon>().m_Attack + Mathf.Round((m_equip.m_Weapon.GetComponent<PlayerWeapon>().m_Attack / 2) * (0.5f * m_equip.GetUGCount()))).ToString();
            }
            
            m_Cost.transform.parent.GetComponent<WeaponUpgrader>().m_equipper = m_equip;

            if (m_equip.GetUGCount() == 5)
            {
                m_Cost.text = "Fully Upgraded";
            }
            else
            {
                m_Cost.text = "Upgrade: " + m_equip.GetUGPrice();
            }
        }
    }

    public void getEquipper(WeaponEquipButton m_e)
    {
        m_equip = m_e;
        m_AffImage1.sprite = m_e.m_affinitySprite.sprite;
        m_AffImage2.sprite = m_e.m_affinitySprite.sprite;
    }
}
