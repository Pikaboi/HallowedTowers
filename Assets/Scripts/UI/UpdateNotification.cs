using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateNotification : MonoBehaviour
{
    public RoundPlayButton m_playButton;

    private Animator m_Self;

    private bool PrevRoundStatus;

    private float timer = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        m_Self = GetComponent<Animator>();
        PrevRoundStatus = true;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(m_playButton.firstRound);
        if (!m_playButton.firstRound)
        {
            if (m_playButton.getRoundStatus() && m_playButton.getRoundStatus() != PrevRoundStatus)
            {
                m_Self.SetBool("Notif", true);
            }

            if (m_Self.GetBool("Notif"))
            {
                timer -= Time.deltaTime;

                if (timer < 0.0f)
                {
                    m_Self.SetBool("Notif", false);
                    timer = 5.0f;
                }
            }

            PrevRoundStatus = m_playButton.getRoundStatus();
        }
    }
}
