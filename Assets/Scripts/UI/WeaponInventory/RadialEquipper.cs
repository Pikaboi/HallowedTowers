using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadialEquipper : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject m_Weapon;
    public Vector3 m_rot;
    void Start()
    {

    }

    // Update is called once per frame
    public void OnClick()
    {
        RadialSetup[] radials = FindObjectsOfType<RadialSetup>();

        foreach(RadialSetup r in radials)
        {
            r.GetEquipper(this);
        }
    }
}
