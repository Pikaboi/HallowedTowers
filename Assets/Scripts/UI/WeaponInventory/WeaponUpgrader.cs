using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponUpgrader : MonoBehaviour
{
    WeaponEquipButton m_equipper;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        m_equipper.Upgrade();
    }
}
