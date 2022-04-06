using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryAdd : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject starterWeapon;
    void Awake()
    {
        addWeapon(starterWeapon);
        WorldCharacter player = FindObjectOfType<WorldCharacter>();
        starterWeapon.GetComponentInChildren<WeaponEquipButton>(true).m_Player = player;
        starterWeapon.GetComponentInChildren<WeaponEquipButton>(true).OnClick();
    }

    private void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RemoveInventoryOnLoad()
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            GameObject g = transform.GetChild(i).gameObject;
            Destroy(g);
        }
    }

    public void addWeapon(GameObject g)
    {
        GameObject newWeapon = Instantiate(g);
        newWeapon.transform.SetParent(transform, false);
    }
}
