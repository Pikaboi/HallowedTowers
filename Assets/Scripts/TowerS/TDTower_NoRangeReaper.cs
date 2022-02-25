using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TDTower_NoRangeReaper : TDTower
{
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        //To get sub towers like Reapers Scythe updated
        TDTower[] childTowers = gameObject.GetComponentsInChildren<TDTower>();

        if (childTowers.Length > 0)
        {
            for (int i = 0; i < childTowers.Length; i++)
            {
                childTowers[i].SetAffinity(m_Affinity);
            }
        }
    }
}
