using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorrectScale : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);   
    }
}
