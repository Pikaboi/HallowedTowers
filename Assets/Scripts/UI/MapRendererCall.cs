using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapRendererCall : MonoBehaviour
{
    public GameObject m_Cam;

    public void turnOffCam()
    {
        m_Cam.SetActive(false);
    }

    public void turnOnCam()
    {
        m_Cam.SetActive(true);
    }

    public void OnOff()
    {
        if (m_Cam.activeSelf)
        {
            m_Cam.SetActive(false);
        } else
        {
            m_Cam.SetActive(true);
        }
    }
}
