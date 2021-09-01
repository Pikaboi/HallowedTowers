using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorControl : MonoBehaviour
{
    [SerializeField] GameObject m_Placer;
    [SerializeField] LayerMask m_layerMask;

    SpriteRenderer m_Marker;
    // Start is called before the first frame update
    void Start()
    {
        m_Marker = m_Placer.GetComponent<SpriteRenderer>();
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

        if (hit.collider != null)
        {
            switch (hit.collider.gameObject.layer)
            {
                case 11: //A Tower
                    //Dont allow them to place a tower
                    m_Marker.color = Color.red;
                    break;
                case 12: //The Space for Towers
                    m_Marker.color = Color.green;
                    break;
                case 13://The NavMesh
                    //Dont Allow them to place a tower
                    m_Marker.color = Color.red;
                    break;
                default:
                    //Any other layer we will ignore
                    m_Marker.color = Color.white;
                    break;
            }
        }
        
        m_Placer.transform.position = new Vector3(mouseX.x, hit.point.y, mouseX.z);
    }
}
