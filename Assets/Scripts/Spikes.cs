using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    [SerializeField] private int m_Resistance;
    [SerializeField] bool m_Slow;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(m_Resistance <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void lowerResistance()
    {
        m_Resistance--;
    }

    public bool getSlow()
    {
        return m_Slow;
    }
}
