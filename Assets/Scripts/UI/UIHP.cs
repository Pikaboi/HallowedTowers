using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHP : MonoBehaviour
{
    public GameObject m_target;
    public Slider m_slider;
    public WorldCharacter m_Player;
    public GameObject m_Radial;
    // Start is called before the first frame update
    void Start()
    {
        m_Player = m_target.GetComponent<WorldCharacter>();
        m_slider.maxValue = m_Player.GetMaxHealth();
        m_slider.value = m_Player.m_health;
        m_Radial.SetActive(false);
    }

    private void Update()
    {
        m_slider.maxValue = m_Player.GetMaxHealth();
        m_slider.value = m_Player.m_health;

        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (m_Radial.activeSelf == false)
            {
                m_Radial.SetActive(true);
            }
            else
            {
                m_Radial.SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = new Vector3(m_target.transform.position.x, m_target.transform.position.y + 3.3f, m_target.transform.position.z);
    }
}
