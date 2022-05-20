using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelEquipper : MonoBehaviour
{
    public WeaponEquipButton m_weapon;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void OnClick()
    {
        m_weapon.OnClick();
    }
}
