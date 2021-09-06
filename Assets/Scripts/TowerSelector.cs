using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSelector : MonoBehaviour
{
    public GameObject Tower;
    GameObject cursor;
    [SerializeField] TMPro.TMP_Text t;

    private void Start()
    {
        cursor = GameObject.FindGameObjectWithTag("Cursor");
        t.text += Tower.GetComponent<TDTowerManager>().m_cost;
    }

    public void SetTower()
    {
        cursor.GetComponent<CursorControl>().m_currentTower = Tower;
        cursor.GetComponent<CursorControl>().m_currentSpike = null;
    }
}
