using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopTrigger : MonoBehaviour
{
    public GameObject m_shopUI;
    public RoundPlayButton m_playButton;
    BoxCollider m_trigger;
    // Start is called before the first frame update
    void Start()
    {
        m_trigger = GetComponent<BoxCollider>();
        m_shopUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (m_playButton.getRoundStatus())
        {
            m_trigger.enabled = true;
        } else
        {
            m_trigger.enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        m_shopUI.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        m_shopUI.SetActive(false);
    }

}
