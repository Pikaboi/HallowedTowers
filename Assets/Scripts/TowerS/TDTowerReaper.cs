using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TDTowerReaper : TDTower
{
    public bool Path2UG2;
    /// <summary>
    /// Lower the cost of affinity changes
    /// </summary>

    public bool Path3UG2;
    /// <summary>
    /// Boost the fire rate if an enemy in range
    /// has the affinity disadvantage
    /// </summary>

    public bool Path3UG3;
    /// <summary>
    /// Boost attack by a lot
    /// But only if there are no towers in its range
    /// </summary>
    
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
    }
}
