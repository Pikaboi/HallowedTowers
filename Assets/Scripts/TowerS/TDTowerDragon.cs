using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TDTowerDragon : TDTower
{
    public enum FlightPath
    {
        HORI,
        VERT,
        CIRCLE,
        FIGURE8,
        INFINITE
    }

    public FlightPath m_flightPath;

    public Rigidbody m_rb;
    public float m_speed;

    public bool notStuck = true;

    [SerializeField] bool circling = true;
    [SerializeField] bool changed = false;

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

        if (!changed)
        {
            FlightPathMove();
        } else
        {
            MoveToCenter();
        }
    }

    public void MoveToCenter()
    {
        Vector3 origin = new Vector3(transform.parent.position.x, transform.position.y, transform.parent.position.z);
        transform.LookAt(origin);

        if (m_speed > 0)
        {
            m_rb.velocity = transform.forward * m_speed;
        } else
        {
            m_rb.velocity = transform.forward * -m_speed;
        }

        if(Vector3.Distance(transform.position, origin) < 1)
        {
            changed = false;
            circling = true;
        }
    }

    public void ChangePath(FlightPath _path)
    {
        m_flightPath = _path;
        changed = true;
    }

    public void FlightPathMove()
    {
        switch (m_flightPath)
        {
            case FlightPath.HORI:

                if (Vector3.Distance(transform.position, transform.parent.position) < 1.0f)
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y, 0.0f);
                }

                if(transform.position.x - transform.parent.position.x <= (m_TriggerRange / 2) && transform.position.x - transform.parent.position.x > 0)
                {
                    notStuck = true;
                } else if (transform.position.x - transform.parent.position.x >= -(m_TriggerRange / 2) && transform.position.x - transform.parent.position.x < 0)
                {
                    notStuck = true;
                }

                if (notStuck)
                {
                    if (transform.position.x - transform.parent.position.x >= m_TriggerRange || transform.position.x - transform.parent.position.x <= -m_TriggerRange)
                    {
                        m_speed = -m_speed;
                        notStuck = false;
                    }
                }

                m_rb.velocity = new Vector3(1.0f, 0.0f, 0.0f) * m_speed;

                transform.forward = m_rb.velocity;
                break;
            case FlightPath.VERT:

                if(Vector3.Distance(transform.position, transform.parent.position) < 1.0f)
                {
                    transform.position = new Vector3(0.0f, transform.position.y, transform.position.z);
                }

                if (transform.position.z - transform.parent.position.z <= (m_TriggerRange / 2) && transform.position.z - transform.parent.position.z > 0)
                {
                    notStuck = true;
                }
                else if (transform.position.z - transform.parent.position.z >= -(m_TriggerRange / 2) && transform.position.z - transform.parent.position.z < 0)
                {
                    notStuck = true;
                }

                if (notStuck)
                {
                    if (transform.position.z - transform.parent.position.z >= m_TriggerRange || transform.position.z - transform.parent.position.z <= -m_TriggerRange)
                    {
                        m_speed = -m_speed;
                        notStuck = false;
                    }
                }

                m_rb.velocity = new Vector3(0.0f, 0.0f, 1.0f) * m_speed;

                transform.forward = m_rb.velocity;
                break;
            case FlightPath.CIRCLE:
                if (circling == true)
                {
                    m_rb.velocity = new Vector3(1.0f, 0.0f, 0.0f) * m_speed;

                    if(Mathf.Abs(transform.position.x - transform.parent.position.x) > m_TriggerRange)
                    {
                        circling = false;
                    }
                } 
                else
                {
                    m_rb.velocity = Vector3.zero;
                    transform.RotateAround(transform.parent.position, Vector3.up, 20 * Time.deltaTime);
                }
                break;
            default:
                break;
        }
    }

}
