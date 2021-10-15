using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TDTowerDragon : TDTower
{
    public Rigidbody m_rb;
    public float m_speed;
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        transform.position += new Vector3(0.0f, 3.0f, 0.0f);
        m_rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();

        if (Vector3.Distance(transform.position, transform.parent.position) > m_TriggerRange)
        {
            Debug.Log("Change");
            m_speed = -m_speed;
        }

        m_rb.velocity = new Vector3(1.0f, 0.0f, 0.0f) * m_speed;

        Debug.Log(Vector3.Distance(transform.position, transform.parent.position));
    }
}
