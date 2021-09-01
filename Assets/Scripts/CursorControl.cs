using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorControl : MonoBehaviour
{
    [SerializeField] GameObject m_Placer;
    [SerializeField] LayerMask m_layerMask;
    public GameObject m_currentTower;

    SpriteRenderer m_Marker;

    bool m_placable = false;

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
                    m_placable = false;
                    break;
                case 12: //The Space for Towers
                    m_Marker.color = Color.green;
                    m_placable = true;
                    break;
                case 13://The NavMesh
                    //Dont Allow them to place a tower
                    m_Marker.color = Color.red;
                    m_placable = false;
                    break;
                default:
                    //Any other layer we will ignore
                    m_Marker.color = Color.white;
                    m_placable = false;
                    break;
            }
        }

        Collider[] col = Physics.OverlapSphere(m_Placer.transform.position, 0.75f);

        foreach(Collider c in col)
        {
            if(c.gameObject.layer == 11)
            {
                m_Marker.color = Color.red;
                m_placable = false;
            }
        }
        
        m_Placer.transform.position = new Vector3(mouseX.x, hit.point.y, mouseX.z);

        if (Input.GetMouseButtonDown(0))
        {
            if(m_currentTower != null && m_placable)
            {
                //Set a tower
                Instantiate(m_currentTower, m_Placer.transform.position + new Vector3(0.0f, 1.0f, 0.0f), transform.rotation);
            }
        }

    }

}
