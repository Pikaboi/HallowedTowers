using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogLiftNotification : MonoBehaviour
{
    private Animator m_Self;

    private float timer = 7.0f;
    // Start is called before the first frame update
    void Start()
    {
        m_Self = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_Self.GetBool("Notif"))
        {
            timer -= Time.deltaTime;

            if (timer < 0.0f)
            {
                m_Self.SetBool("Notif", false);
                timer = 5.0f;
            }
        }
    }

    public void Animate()
    {
        m_Self.SetBool("Notif", true);
    }
}
