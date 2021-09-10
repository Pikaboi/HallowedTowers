using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMove : MonoBehaviour
{
    public GameObject m_follow;
    public float xBoundsMax;
    public float xBoundsMin;
    public float zBoundsMax;
    public float zBoundsMin;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = new Vector3(Mathf.Clamp(m_follow.transform.position.x, xBoundsMax, xBoundsMin), transform.position.y, Mathf.Clamp(m_follow.transform.position.z, zBoundsMax, zBoundsMin));
    }
}
