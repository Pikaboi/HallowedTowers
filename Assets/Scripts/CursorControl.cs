using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorControl : MonoBehaviour
{
    [SerializeField] GameObject m_Placer;
    [SerializeField] LayerMask m_layerMask;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mouseX = Input.mousePosition;

        mouseX = Camera.main.ScreenToWorldPoint(new Vector3(mouseX.x, mouseX.y, Camera.main.transform.position.y));

        Vector3 direction = Camera.main.transform.position - m_Placer.transform.position;
        direction = direction.normalized;

        RaycastHit hit;
        Physics.Raycast(Camera.main.transform.position, -direction, out hit, Mathf.Infinity, m_layerMask);

        m_Placer.transform.position = new Vector3(mouseX.x, hit.point.y, mouseX.z);
    }
}
