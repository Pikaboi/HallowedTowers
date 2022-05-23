using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSelector : MonoBehaviour
{
    public GameObject Tower;
    GameObject cursor;
    [SerializeField] TMPro.TMP_Text t;
    private GlobalWorldController m_global;
    public int unlockRound;

    private void Start()
    {
        cursor = GameObject.FindGameObjectWithTag("Cursor");
        t.text += Tower.GetComponent<TDTowerManager>().m_cost;
        m_global = FindObjectOfType<GlobalWorldController>();
    }

    public void Update()
    {
        if(m_global.RoundNum >= unlockRound)
        {
            gameObject.GetComponent<UnityEngine.UI.Image>().enabled = true;
            gameObject.GetComponent<UnityEngine.UI.Button>().enabled = true;
            gameObject.GetComponentInChildren<TMPro.TMP_Text>().enabled = true;
        }  else
        {
            gameObject.GetComponent<UnityEngine.UI.Image>().enabled = false;
            gameObject.GetComponent<UnityEngine.UI.Button>().enabled = false;
            gameObject.GetComponentInChildren<TMPro.TMP_Text>().enabled = false;
        }
    }

    public void SetTower()
    {
        cursor.GetComponent<CursorControl>().m_currentTower = Tower;
        cursor.GetComponent<CursorControl>().m_currentSpike = null;
        cursor.GetComponent<CursorControl>().SetMarkerSprite(gameObject.GetComponent<UnityEngine.UI.Image>().sprite);
    }
}
