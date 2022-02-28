using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
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

    public AudioSource m_spawnSFX;

    public bool m_configure = false;

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
        if (!m_configure)
        {
            DetectTowerInRange();
            ClickControls();
        }
    }

    void CursorMovement()
    {
        Ray r = Camera.main.ScreenPointToRay(Input.mousePosition); //Physics.Raycast(Camera.main.transform.position, -direction, out hit, Mathf.Infinity, m_layerMask);
        
        Physics.Raycast(r, out hit);

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
                        if (m_currentTower.gameObject.tag == "Kraken")
                        {
                            m_Marker.color = Color.red;
                            m_placable = false;
                        }
                        else
                        {
                            m_Marker.color = Color.green;
                            m_placable = true;
                        }
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
                case 16: //The water for krakens
                    if (m_currentTower != null)
                    {
                        if (m_currentTower.gameObject.tag == "Kraken")
                        {
                            m_Marker.color = Color.green;
                            m_placable = true;
                        }
                        else
                        {
                            m_Marker.color = Color.red;
                            m_placable = false;
                        }
                    }
                    else if (m_currentSpike != null)
                    {
                        m_Marker.color = Color.red;
                        m_placable = false;
                    }
                    break;
                default:
                    //Any other layer we will ignore
                    m_Marker.color = Color.white;
                    m_placable = false;
                    break;
            }
        }

        if (EventSystem.current.IsPointerOverGameObject())
        {
            m_Marker.color = Color.white;
            m_placable = false;
        }

        m_Placer.transform.position = hit.point + new Vector3(0.0f, 0.1f, 0.0f);
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
            if (m_currentTower != null && m_placable && !EventSystem.current.IsPointerOverGameObject())
            {
                if (m_resource.m_Money >= GetTowerScript().m_cost)
                {
                    //Set a tower
                    Instantiate(m_currentTower, m_Placer.transform.position + new Vector3(0.0f, 1.0f, 0.0f), transform.rotation);
                    m_resource.SubMoney(GetTowerScript().m_cost);
                    m_spawnSFX.Play();
                }
                m_currentTower = null;
            }

            if (m_currentSpike != null && m_placable && !EventSystem.current.IsPointerOverGameObject())
            {
                if (m_resource.m_Money >= m_currentSpike.GetComponent<Spikes>().getCost())
                {
                    Instantiate(m_currentSpike, m_Placer.transform.position, transform.rotation);
                    m_currentSpike.GetComponent<Spikes>().PayForSpikes();
                    m_spawnSFX.Play();
                }
                m_currentSpike = null;
            }

            if (m_currentTower == null && m_currentSpike == null && hit.collider != null && hit.collider.gameObject.GetComponent<WorldCharacter>() == null && hit.collider.gameObject.layer == 11 && !EventSystem.current.IsPointerOverGameObject())
            {
                if (m_selectedTower != null)
                {
                    GetSelectedTowerScript().hideRange();
                }
                m_selectedTower = hit.collider.gameObject;
                GetSelectedTowerScript().showRange();
            }

            if (m_selectedTower != null && hit.collider != null && hit.collider.gameObject.layer != 11 && !EventSystem.current.IsPointerOverGameObject())
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
