using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapBack : MonoBehaviour
{
    [SerializeField] GameObject[] AreaMaps;
    [SerializeField] MapRendererCall[] m_rendercams;
    [SerializeField] GameObject mainMap;
    [SerializeField] MapRendererCall m_cam;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void MapGoBack()
    {
        bool noneOpen = true;
        foreach(GameObject m in AreaMaps)
        {
            if(m.activeSelf == true)
            {
                m.SetActive(false);
                noneOpen = false;
            }
        }

        if (!noneOpen)
        {
            foreach(MapRendererCall map in m_rendercams)
            {
                if (map.m_Cam.activeSelf)
                {
                    map.turnOffCam();
                }
            }

            m_cam.turnOnCam();
        }

        if (noneOpen)
        {
            mainMap.SetActive(false);
            m_cam.OnOff();
        }
    }
}
