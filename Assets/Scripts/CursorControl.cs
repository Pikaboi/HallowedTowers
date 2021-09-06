using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorControl : MonoBehaviour
{
    [SerializeField] GameObject m_Placer;
    [SerializeField] LayerMask m_layerMask;
    public GameObject m_currentTower;
    public GameObject m_selectedTower;
    public GameObject m_currentSpike;

    [SerializeField] PlayerResourceManager m_resource;

    SpriteRenderer m_Marker;

    RaycastHit hit;

    bool m_placable = false;

    // Start is called before the first frame update
    void Start()
    {
        m_Marker = m_Placer.GetComponent<SpriteRenderer>();
        m_resource = FindObjectOfType<PlayerResourceManager>();
    }

    // Update is called once per frame
    void Update()
    {
        CursorMovement();
        DetectTowerInRange();
        ClickControls();
    }

    void CursorMovement()
    {
        Vector3 mouseX = Input.mousePosition;

        mouseX = Camera.main.ScreenToWorldPoint(new Vector3(mouseX.x, mouseX.y, Camera.main.transform.position.y));

        Vector3 direction = Camera.main.transform.position - m_Placer.transform.position;
        direction = direction.normalized;

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
                    if (m_currentTower != null)
                    {
                        m_Marker.color = Color.green;
                        m_placable = true;
                    } else if(m_currentSpike != null)
                    {
                        m_Marker.color = Color.red;
                        m_placable = false;
                    }
                    break;
                case 13://The NavMesh
                    //Dont Allow them to place a tower
                    if (m_currentTower != null)
                    {
                        m_Marker.color = Color.red;
                        m_placable = false;
                    }
                    else if (m_currentSpike != null)
                    {
                        m_Marker.color = Color.green;
                        m_placable = true;
                    }
                    break;
                default:
                    //Any other layer we will ignore
                    m_Marker.color = Color.white;
                    m_placable = false;
                    break;
            }
        }

        m_Placer.transform.position = new Vector3(mouseX.x, hit.point.y, mouseX.z);
    }

    void DetectTowerInRange()
    {
        Collider[] col = Physics.OverlapSphere(m_Placer.transform.position, 0.75f);

        foreach (Collider c in col)
        {
            if (c.gameObject.layer == 11)
            {
                m_Marker.color = Color.red;
                m_placable = false;
            }
        }
    }

    void ClickControls()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (m_currentTower != null && m_placable)
            {
                //Set a tower
                Instantiate(m_currentTower, m_Placer.transform.position + new Vector3(0.0f, 1.0f, 0.0f), transform.rotation);
                m_resource.SubMoney(GetTowerScript().m_cost);
                m_currentTower = null;
            }

            if (m_currentSpike != null && m_placable)
            {
                Instantiate(m_currentSpike, m_Placer.transform.position, transform.rotation);
                m_currentSpike.GetComponent<Spikes>().PayForSpikes();
                m_currentSpike = null;
            }

            if (m_currentTower == null && m_currentSpike == null && hit.collider != null && hit.collider.gameObject.layer == 11)
            {
                if (m_selectedTower != null)
                {
                    GetSelectedTowerScript().hideRange();
                }
                m_selectedTower = hit.collider.gameObject;
                GetSelectedTowerScript().showRange();
            }

            if (m_selectedTower != null && hit.collider != null && hit.collider.gameObject.layer != 11)
            {
                GetSelectedTowerScript().hideRange();
                m_selectedTower = null;
            }
        }
    }

    public TDTowerManager GetTowerScript()
    {
        return m_currentTower.GetComponent<TDTowerManager>();
    }

    public TDTowerManager GetSelectedTowerScript()
    {
        return m_selectedTower.GetComponent<TDTowerManager>();
    }
}
