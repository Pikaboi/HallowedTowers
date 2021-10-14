using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapButton : MonoBehaviour
{
    [SerializeField] GameObject mapRoot;
    // Start is called before the first frame update
    void Start()
    {
        mapRoot.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        if (mapRoot.activeSelf == false)
        {
            mapRoot.SetActive(true);
        } else
        {
            mapRoot.SetActive(false);
        }
    }
}
