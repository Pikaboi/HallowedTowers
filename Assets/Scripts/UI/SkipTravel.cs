using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkipTravel : MonoBehaviour
{
    [SerializeField] private GameObject m_warppoint;
    [SerializeField] private GameObject m_Player;
    [SerializeField] private MapButton m_mapButton;
    // Start is called before the first frame update
    void Start()
    {
        m_Player = GameObject.FindGameObjectWithTag("Player");
    }

    public void OnClick()
    {
        m_Player.transform.position = m_warppoint.transform.position;
        //Exit the map after the skip travel
        m_mapButton.OnClick();
    }
}
