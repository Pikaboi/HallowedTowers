using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryAdd : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject starterWeapon;
    void Awake()
    {
        WorldCharacter player = FindObjectOfType<WorldCharacter>();
        starterWeapon.GetComponentInChildren<WeaponEquipButton>(true).m_Player = player;
        addWeapon(starterWeapon);
    }

    private void Start()
    {
        starterWeapon.GetComponentInChildren<WeaponEquipButton>(true).OnClick();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void addWeapon(GameObject g)
    {
        GameObject newWeapon = Instantiate(g);
        newWeapon.transform.SetParent(transform, false);
    }
}
