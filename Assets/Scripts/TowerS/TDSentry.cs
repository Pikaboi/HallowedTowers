using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TDSentry : MonoBehaviour
{
    private float lifespan = 20;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SetLifetime(float m_time)
    {
        lifespan = m_time;
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
