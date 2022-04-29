using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TDTower_Kraken : TDTower
{
    public bool Path1UG1;
    /// <summary>
    /// Lower Fire Rate to 0.5
    /// Lower Range to 15
    /// </summary>

    public bool Path1UG3;
    /// <summary>
    /// Shoots 3 bullets instead
    /// </summary>

    //Homing in on enemies
    public List<TDEnemy> m_targets;
    

    public Vector3 AimPos = new Vector3 (0.0f, 0.0f, 0.0f);

    [SerializeField] LineRenderer lr;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();

        lr = GetComponentInChildren<LineRenderer>();

        if (Path1UG1)
        {
            m_fireRate = 0.5f;
            m_TriggerRange = 15f;
            m_Trigger.radius = m_TriggerRange;
            m_RadiusViewer.transform.localScale = new Vector3(m_TriggerRange * 2, m_RadiusViewer.transform.localScale.y, m_TriggerRange * 2);
        }

        lr.enabled = false;
        AimPos = transform.parent.GetComponent<TDTower_KrakenManager>().aimpos = AimPos;

        if(AimPos == Vector3.zero) {
            Debug.Log("Targeting");
            SetTarget();
        }
    }

    public override void Aim()
    {
        Vector3 lookat = AimPos - transform.position;
        lookat.y = 0;
        Quaternion Rotation = Quaternion.LookRotation(lookat);
        transform.rotation = Quaternion.Slerp(transform.rotation, Rotation, 1);

        m_aimer.transform.LookAt(AimPos);
    }

    public void SetTarget()
    {
        StartCoroutine(GetAimPos());
    }

    // Update is called once per frame
    public override void Update()
    {
        Aim();
        CheckEnemies();
        m_FireTimer -= Time.deltaTime;

        if (m_InRange)
        {
            if (m_FireTimer <= 0.0f)
            {
                if (Path1UG3)
                {
                    float angle = -10.0f;
                    for (int i = 0; i < 3; i++)
                    {
                        GameObject bulleti = Instantiate(m_Projectile, transform.position + transform.forward * 1.5f, m_aimer.transform.rotation);
                        bulleti.transform.Rotate(new Vector3(0.0f, angle, 0.0f));
                        angle += 10;
                        bulleti.GetComponent<TDProjectile>().InheritFromTower(m_TriggerRange, m_attack, gameObject, m_Affinity);
                        if (m_targets.Count > i && m_targets[i] != null)
                        {
                            bulleti.GetComponent<TDProjectileKraken>().getTarget(m_targets[i]);
                        }
                    }
                }
                else
                {
                    GameObject bullet = Instantiate(m_Projectile, transform.position + transform.forward * 1.5f, m_aimer.transform.rotation);
                    bullet.GetComponent<TDProjectile>().InheritFromTower(m_TriggerRange, m_attack, gameObject, m_Affinity);
                    if (m_targets.Count > 0)
                    {
                        bullet.GetComponent<TDProjectileKraken>().getTarget(m_targets[0]);
                    }
                }
                m_FireTimer = m_fireRate - (m_fireRate * m_fireRateBuff);
            }
        }
    }

    public override void CheckEnemies()
    {
        m_targets.Clear();

        Collider[] ObjsInRange = Physics.OverlapSphere(transform.position, m_TriggerRange);

        bool range = false;

        foreach (Collider Obj in ObjsInRange)
        {
            if (Obj.gameObject.tag == "Enemy")
            {
                range = true;
                if (m_targets.Count < 3 && !m_targets.Contains(Obj.gameObject.GetComponent<TDEnemy>()))
                {
                    m_targets.Add(Obj.gameObject.GetComponent<TDEnemy>());
                }
            }
        }

        m_InRange = range;
    }

    private IEnumerator GetAimPos()
    {
        yield return new WaitForSeconds(0.1f);

        lr.enabled = true;
        lr.SetPosition(0, transform.position);
        lr.SetPosition(1, transform.position);
        //Turn off buttons while waiting for response
        Button[] buttons = GameObject.FindObjectsOfType<Button>();
        Debug.Log(buttons.Length);

        foreach (Button b in buttons)
        {
            b.enabled = false;
        }

        GameObject.FindObjectOfType<CursorControl>().m_configure = true;

        yield return waitforClick();

        //Turn them back on once we are set up
        foreach (Button b in buttons)
        {
            b.enabled = true;
        }

        GameObject.FindObjectOfType<CursorControl>().m_configure = false;

        lr.enabled = false;
    }

    private IEnumerator waitforClick()
    {
        bool click = false;
        while (!click)
        {
            //Tooken from Cursor Control for proper mouse position
            Vector3 mouseX = Input.mousePosition;
            mouseX = Camera.main.ScreenToWorldPoint(new Vector3(mouseX.x, mouseX.y, Camera.main.transform.position.y));

            if(Vector3.Distance(transform.position, mouseX) > m_TriggerRange)
            {
                lr.SetPosition(1, transform.position - (transform.position - mouseX).normalized * m_TriggerRange);
            } else
            {
                lr.SetPosition(1, mouseX);
            }
            
            //Vector3 pos = new Vector3(mousepos.x, transform.position.y, mousepos.z);
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log(true);
                AimPos = new Vector3(mouseX.x, transform.position.y, mouseX.z);
                transform.parent.GetComponent<TDTower_KrakenManager>().aimpos = AimPos;
                click = true;
            }
            yield return null;
        }
    }
}
