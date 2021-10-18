using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TDProjectilePierce : TDProjectile
{
    public int m_PeirceCount;
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

    public override void OnCollisionEnter(Collision collision)
    {
        //We dont use OnCollisionEnter for peirce so we override the function
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            m_PeirceCount--;
            other.GetComponent<TDEnemy>().DamageEnemy(m_attack, m_Affinity);
        }
    }
}
