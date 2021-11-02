using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponEquipButton : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject m_Weapon;
    public WorldCharacter m_Player;
    public Vector3 m_rot;
    void Start()
    {
        m_Player = FindObjectOfType<WorldCharacter>();
    }

    // Update is called once per frame
    public void OnClick()
    {
        m_Player.SpawnWeapon(m_Weapon, m_rot);
    }
}
