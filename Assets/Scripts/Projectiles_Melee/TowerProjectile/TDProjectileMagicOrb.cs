using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TDProjectileMagicOrb : TDProjectile
{
    public bool m_inflictDOT = false;
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
                DamageEnemy(m_attack, c.gameObject.GetComponent<TDEnemy>());
                c.GetComponent<TDEnemy>().InflictDOT(m_inflictDOT);
            }
        }

        Destroy(gameObject);
    }
}

