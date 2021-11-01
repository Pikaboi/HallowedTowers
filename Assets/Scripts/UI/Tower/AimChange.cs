using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimChange : MonoBehaviour
{
    public TDTower_Kraken m_kraken;
    public Vector3 m_AimPos;
    // Start is called before the first frame update
    void Start()
    {
        //Button Parent is the Canvas
        //Canvas Parent is the Upgrade UI prefab
        //Upgrade UI Parent is the Tower Manager
        //Thus, since we change the prefab constantly, we gotta do this
        m_kraken = transform.parent.parent.parent.GetComponentInChildren<TDTower_Kraken>();
    }

    private void Update()
    {
        m_kraken = transform.parent.parent.parent.GetComponentInChildren<TDTower_Kraken>();
    }

    public void ReAim()
    {
        m_kraken.SetTarget();
    }
}
