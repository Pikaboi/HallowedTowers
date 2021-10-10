using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeUI : MonoBehaviour
{
    /*// Start is called before the first frame update
    [SerializeField] CursorControl m_cursor;
    [SerializeField] Button m_UG1;
    [SerializeField] Button m_UG2;
    [SerializeField] TMPro.TMP_Text m_UG1T;
    [SerializeField] TMPro.TMP_Text m_UG2T;
    void Start()
    {
        m_UG1.enabled = false;
        m_UG1.gameObject.GetComponent<Image>().enabled = false;
        m_UG2.enabled = false;
        m_UG2.gameObject.GetComponent<Image>().enabled = false;
        m_UG1T.enabled = false;
        m_UG2T.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //I do not like how messy it is
        if(m_cursor.m_selectedTower != null)
        {
            m_UG1.gameObject.GetComponent<Image>().enabled = true;
            m_UG2.gameObject.GetComponent<Image>().enabled = true;
            m_UG1T.enabled = true;
            m_UG2T.enabled = true;

            if (m_cursor.GetSelectedTowerScript().m_UG1Bought)
            {
                m_UG1T.text = "Purchased";
                m_UG1.enabled = false;
            } else
            {
                m_UG1.enabled = true;
                m_UG1T.text = "Upgrade 1: " + m_cursor.GetSelectedTowerScript().m_UG1String + " " + m_cursor.GetSelectedTowerScript().m_UG1Cost;
            }

            if (m_cursor.GetSelectedTowerScript().m_UG2Bought)
            {
                m_UG2T.text = "Purchased";
                m_UG2.enabled = false;
            }
            else
            {
                m_UG2.enabled = true;
                m_UG2T.text = "Upgrade 2: " + m_cursor.GetSelectedTowerScript().m_UG2String + " " + m_cursor.GetSelectedTowerScript().m_UG2Cost;
            }
        } else
        {
            m_UG1.enabled = false;
            m_UG1.gameObject.GetComponent<Image>().enabled = false;
            m_UG2.enabled = false;
            m_UG2.gameObject.GetComponent<Image>().enabled = false;
            m_UG1T.enabled = false;
            m_UG2T.enabled = false;
        }
    }

    public void UG1Click()
    {
        if(m_cursor.m_selectedTower != null)
        {
            m_cursor.GetSelectedTowerScript().Upgrade1();
        }
    }
    public void UG2Click()
    {
        if (m_cursor.m_selectedTower != null)
        {
            m_cursor.GetSelectedTowerScript().Upgrade2();
        }
    }*/
}
