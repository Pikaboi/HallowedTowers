using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TDTower_ChangeDragon : MonoBehaviour
{
    [SerializeField] private TDTowerManager m_main;
    TDTowerDragon m_dragon;

    public TDTowerDragon.FlightPath m_flightPath;
    // Start is called before the first frame update
    void Start()
    {
        //m_dragon = m_main.m_child.GetComponent<TDTowerDragon>();
    }

    // Update is called once per frame
    void Update()
    {
        //Update current Dragon
        m_dragon = m_main.m_child.GetComponent<TDTowerDragon>();
    }

    public void OnClick()
    {
        m_dragon.ChangePath(m_flightPath);
    }

    public void turnOn()
    {
        transform.GetComponent<UnityEngine.UI.Button>().enabled = true;
        transform.GetComponent<UnityEngine.UI.Image>().enabled = true;
        transform.GetComponentInChildren<TMPro.TMP_Text>().enabled = true;
    }

    public void turnOff()
    {
        transform.GetComponent<UnityEngine.UI.Button>().enabled = false;
        transform.GetComponent<UnityEngine.UI.Image>().enabled = false;
        transform.GetComponentInChildren<TMPro.TMP_Text>().enabled = false;
    }
}
