using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryAdd : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void addWeapon(GameObject g)
    {
        GameObject newWeapon = Instantiate(g);
        newWeapon.transform.parent = gameObject.transform;
    }
}
