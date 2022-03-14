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
            m_WeaponName.text = m_equip.m_Weapon.name;
        }
    }

    public void getEquipper(WeaponEquipButton m_e)
    {
        m_equip = m_e;
    }
}
