using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TDSentry : MonoBehaviour
{
    public float lifespan = 20;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lifespan -= Time.deltaTime;

        if(lifespan < 0)
        {
            Destroy(gameObject);
        }
    }
}
