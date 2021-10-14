using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TDTower_Kraken : TDTower
{
    [SerializeField] Vector3 AimPos = new Vector3 (10.0f, 0.0f, 0.0f);
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        SetTarget();
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
        Button[] buttons = GameObject.FindObjectsOfType<Button>();
        //Debug.Log(buttons.Length);

        foreach(Button b in buttons)
        {
            b.enabled = false;
        }

        StartCoroutine(GetAimPos());

        //foreach (Button b in buttons)
        //{
        //    b.enabled = true;
        //}
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
            m_FireTimer = m_fireRate;
        }
    }

    private IEnumerator GetAimPos()
    {
        yield return new WaitForSeconds(0.1f);
        Button[] buttons = GameObject.FindObjectsOfType<Button>();
        Debug.Log(buttons.Length);

        foreach (Button b in buttons)
        {
            b.enabled = false;
        }
        yield return waitforClick();

        foreach (Button b in buttons)
        {
            b.enabled = true;
        }
    }

    private IEnumerator waitforClick()
    {
        bool click = false;
        while (!click)
        {
            //Tooken from Cursor Control for proper mouse position
            Vector3 mouseX = Input.mousePosition;
            mouseX = Camera.main.ScreenToWorldPoint(new Vector3(mouseX.x, mouseX.y, Camera.main.transform.position.y));
            //Vector3 pos = new Vector3(mousepos.x, transform.position.y, mousepos.z);
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log(true);
                AimPos = mouseX;
                click = true;
            }
            yield return null;
        }
    }
}
