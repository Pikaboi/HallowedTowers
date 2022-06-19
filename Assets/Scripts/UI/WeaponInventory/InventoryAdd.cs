using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryAdd : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject starterWeapon;
    void Awake()
    {

    }

    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void setUpWeapon()
    {
        if (transform.childCount == 0)
        {
            addWeapon(starterWeapon);
        }
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
        newWeapon.GetComponentInChildren<WeaponEquipButton>().id = (transform.childCount - 1);
    }
}
