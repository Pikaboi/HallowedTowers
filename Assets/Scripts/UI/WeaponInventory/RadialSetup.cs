using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RadialSetup : MonoBehaviour
{
    public WeaponEquipButton m_Radial;
    bool m_Configure = false;
    RadialEquipper m_equipper;
    Button m_button;
    // Start is called before the first frame update
    void Start()
    {
        m_button = GetComponent<Button>();
    }

    private void Update()
    {
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
        if(m_equipper != null || m_equipper.m_Weapon == m_Radial.m_Weapon)
        {
            CheckForWeaponOnRadial(m_equipper.m_Weapon);
            m_Radial.m_Weapon = m_equipper.m_Weapon;
            m_Radial.m_rot = m_equipper.m_rot;

            m_equipper = null;
            m_Configure = false;
        }
    }

    public void GetEquipper(RadialEquipper _rEquip)
    {
        m_equipper = _rEquip;
        m_Configure = true;
    }

    public void CheckForWeaponOnRadial(GameObject _weapon)
    {
        RadialSetup[] radials = FindObjectsOfType<RadialSetup>();

        foreach(RadialSetup r in radials)
        {
            if(r != this)
            {
                if (r.m_Radial.m_Weapon == _weapon)
                {
                    r.m_Radial.m_Weapon = m_Radial.m_Weapon;
                }
            }
        }
    }
}
