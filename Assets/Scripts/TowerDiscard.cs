using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerDiscard : MonoBehaviour
{
    GameObject cursor;

    private void Start()
    {
        cursor = GameObject.FindGameObjectWithTag("Cursor");
    }

    public void removeTower()
    {
        if (cursor.GetComponent<CursorControl>().m_currentTower != null)
        {
            cursor.GetComponent<CursorControl>().m_currentTower = null;
        }
    }

    public void deleteTower()
    {
        if (cursor.GetComponent<CursorControl>().m_selectedTower != null)
        {
            Destroy(cursor.GetComponent<CursorControl>().m_selectedTower);
            cursor.GetComponent<CursorControl>().m_selectedTower = null;
        }
    }
}
