using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderWeb : MonoBehaviour
{
    private float timer = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        
        if(timer <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            other.GetComponent<TDEnemy>().SlowDebuff();
        }
    }
}
