using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowResources : MonoBehaviour
{
    PlayerResourceManager m_resource;
    TMPro.TMP_Text text;

    [SerializeField] bool showingMoney;
    // Start is called before the first frame update
    void Start()
    {
        m_resource = FindObjectOfType<PlayerResourceManager>();
        text = GetComponent<TMPro.TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (showingMoney)
        {
            GetMoney();
        } else
        {
            GetWorldHealth();
        }
    }

    void GetWorldHealth()
    {
        text.text = m_resource.m_WorldHealth.ToString();
    }

    void GetMoney()
    {
        text.text = m_resource.m_Money.ToString();
    }
}
