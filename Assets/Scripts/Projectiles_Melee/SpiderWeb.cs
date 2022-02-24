using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderWeb : MonoBehaviour
{
    private float timer = 10.0f;

    public bool Path2UG1;
    /// <summary>
    /// Deal Damage when the enemy is hit.
    /// </summary>

    public bool Path2UG3;
    /// <summary>
    /// Extend an Enemies current DOT when on it
    /// </summary>

    public bool Path3UG1;
    /// <summary>
    /// Candy bonus when enemies are defeated on a web
    /// </summary>

    public bool Path3UG2;
    /// <summary>
    /// Gain candy every second any enemy is on the web.
    /// </summary>

    public float m_Attack;

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
            other.GetComponent<TDEnemy>().m_CurrentWeb = this;

            other.GetComponent<TDEnemy>().SlowDebuff();

            if (Path2UG3 && other.GetComponent<TDEnemy>().damageOverTime)
            {
                other.GetComponent<TDEnemy>().AfflictionTimer = other.GetComponent<TDEnemy>().AfflictionTime;
            }

            if (Path3UG2)
            {
                other.GetComponent<TDEnemy>().m_resource.AddMoney(20);
            }

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.GetComponent<TDEnemy>().m_CurrentWeb = null;
        }
    }
}
