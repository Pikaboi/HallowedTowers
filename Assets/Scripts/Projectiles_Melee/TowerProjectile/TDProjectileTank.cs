using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TDProjectileTank : TDProjectile
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
            DamageEnemy(m_attack, other.gameObject.GetComponent<TDEnemy>());
        }
    }
}
