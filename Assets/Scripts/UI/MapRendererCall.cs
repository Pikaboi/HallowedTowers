using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapRendererCall : MonoBehaviour
{
    public GameObject m_Cam;
    public bool m_current;

    public void turnOffCam()
    {
        m_current = false;
        m_Cam.SetActive(false);
    }

    public void turnOnCam()
    {
        m_current = true;
        m_Cam.SetActive(true);
    }

    public void OnOff()
    {
        if (m_current)
        {
            if (m_Cam.activeSelf)
            {
                m_Cam.SetActive(false);
            }
            else
            {
                m_Cam.SetActive(true);
            }
        }
    }
}
