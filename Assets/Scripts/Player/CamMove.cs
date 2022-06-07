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
    public float yBoundsMin;
    public float yBoundsMax;

    public float offset;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y - Input.mouseScrollDelta.y, yBoundsMin, yBoundsMax), transform.position.z);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 desired = new Vector3(Mathf.Clamp(m_follow.transform.position.x, xBoundsMax, xBoundsMin), transform.position.y, Mathf.Clamp(m_follow.transform.position.z - offset, zBoundsMax, zBoundsMin));
        Vector3 smoothed = Vector3.Lerp(transform.position, desired, 0.1f);
        transform.position = smoothed;
    }
}
