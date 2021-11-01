using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapBack : MonoBehaviour
{
    [SerializeField] GameObject[] AreaMaps;
    [SerializeField] GameObject mainMap;
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

        if (noneOpen)
        {
            mainMap.SetActive(false);
        }
    }
}
