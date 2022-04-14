using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowWeaponAttack : MonoBehaviour
{
    public WeaponEquipButton m_weapon;
    public TMPro.TMP_Text t;
    // Start is called before the first frame update
    void Start()
    {
        t = GetComponent<TMPro.TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        t.text = "Attack: " + (m_weapon.m_Weapon.GetComponent<PlayerWeapon>().m_Attack + m_weapon.attackBoost);
    }
}
