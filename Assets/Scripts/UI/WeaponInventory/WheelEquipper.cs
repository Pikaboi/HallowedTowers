using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelEquipper : MonoBehaviour
{
    public WeaponEquipButton m_weapon;
    public int weaponid;
    public bool equipped = false;
    private TMPro.TMP_Text t;
    public UnityEngine.UI.Image m_weaponImage;
    public Sprite blankImg;
    // Start is called before the first frame update
    void Start()
    {
        blankImg = m_weaponImage.sprite;
        t = GetComponentInChildren<TMPro.TMP_Text>();
        if (equipped)
        {
            m_weapon = FindObjectOfType<InventoryAdd>().transform.GetChild(weaponid).GetComponentInChildren<WeaponEquipButton>();
            UpdateStats();
        }
    }

    private void Update()
    {
        if (m_weapon == null)
        {
            equipped = false;
            t.text = "";
            m_weaponImage.sprite = blankImg;
        }
    }

    public void UpdateStats()
    {
        if (m_weapon != null)
        {
            equipped = true;
            weaponid = m_weapon.id;
            m_weaponImage.sprite = m_weapon.m_WeaponImage;
            t.text = m_weapon.m_Weapon.name;
        }
        else
        {
            equipped = false;
            t.text = "";
            m_weaponImage.sprite = blankImg;
        }
    }

    // Update is called once per frame
    public void OnClick()
    {
        if (equipped)
        {
            m_weapon.OnClick();
        }
    }
}
