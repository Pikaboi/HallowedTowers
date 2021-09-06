using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TDProjectileBlast : TDProjectile
{
    public bool inflictDOT = false;
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
        Collider[] cols = Physics.OverlapSphere(transform.position, 4.0f);

        foreach (Collider c in cols)
        {
            if (c.gameObject.tag == "Enemy")
            {
                c.GetComponent<TDEnemy>().DamageEnemy(m_attack, inflictDOT);
            }
        }

        Destroy(gameObject);
    }
}

