using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TDTower_Kraken : TDTower
{
    public Vector3 AimPos = new Vector3 (0.0f, 0.0f, 0.0f);

    [SerializeField] LineRenderer lr;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
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
        m_FireTimer -= Time.deltaTime;

        if (m_FireTimer <= 0.0f)
        {
            GameObject bullet = Instantiate(m_Projectile, transform.position + transform.forward * 1.5f, m_aimer.transform.rotation);
            bullet.GetComponent<TDProjectile>().InheritFromTower(m_TriggerRange, m_attack, gameObject, m_Affinity);
            m_FireTimer = m_fireRate - (m_fireRate * m_fireRateBuff);
        }
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
