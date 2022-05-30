using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RadialSetup : MonoBehaviour
{
    public WheelEquipper m_Radial;
    public Image m_weaponImg;
    bool m_Configure = false;
    RadialEquipper m_equipper;
    Button m_button;
    // Start is called before the first frame update
    void Start()
    {
        m_button = GetComponent<Button>();
        GetComponent<Image>().alphaHitTestMinimumThreshold = 1f;
    }

    private void Update()
    {
        if (m_Radial != null)
        {
            if (m_Radial.m_weapon != null)
            {
                GetComponentInChildren<TMPro.TMP_Text>().text = m_Radial.m_weapon.m_Weapon.name;
            } else
            {
                GetComponentInChildren<TMPro.TMP_Text>().text = "";
            }
        }
        if (m_Configure)
        {
            m_button.enabled = true;
        } else
        {
            m_button.enabled = false;
        }
    }

    // Update is called once per frame
    public void OnClick()
    {
        if(m_equipper != null)
        {
            CheckForWeaponOnRadial(m_equipper.m_Weapon);
            m_Radial.m_weapon = m_equipper.m_Weapon;
            m_weaponImg.sprite = m_equipper.m_WeaponImage;
            m_Radial.UpdateStats();

            RadialSetup[] radials = FindObjectsOfType<RadialSetup>();

            foreach (RadialSetup r in radials)
            {
                r.m_equipper = null;
                r.m_Configure = false;
            }
            //m_equipper = null;
            //m_Configure = false;
        }
    }

    public void GetEquipper(RadialEquipper _rEquip)
    {
        m_equipper = _rEquip;
        m_Configure = true;
    }

    public void CheckForWeaponOnRadial(WeaponEquipButton _weapon)
    {
        RadialSetup[] radials = FindObjectsOfType<RadialSetup>();

        foreach(RadialSetup r in radials)
        {
            if(r != this)
            {
                if (r.m_Radial.m_weapon == _weapon)
                {
                    r.m_Radial.m_weapon = m_Radial.m_weapon;
                }
            }
        }
    }
}
