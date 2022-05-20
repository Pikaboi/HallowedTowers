using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelEquipper : MonoBehaviour
{
    public WeaponEquipButton m_weapon;
    public int weaponid;
    public bool equipped = false;
    private TMPro.TMP_Text t;
    // Start is called before the first frame update
    void Start()
    {
        t = GetComponentInChildren<TMPro.TMP_Text>();
        if (equipped)
        {
            m_weapon = FindObjectOfType<InventoryAdd>().transform.GetChild(weaponid).GetComponentInChildren<WeaponEquipButton>();
        }
    }

    private void Update()
    {
        
    }

    public void UpdateStats()
    {
        if (m_weapon != null)
        {
            equipped = true;
            weaponid = m_weapon.id;
            t.text = m_weapon.name;
        }
        else
        {
            equipped = false;
            t.text = "";
        }
    }

    // Update is called once per frame
    public void OnClick()
    {
        m_weapon.OnClick();
    }
}
