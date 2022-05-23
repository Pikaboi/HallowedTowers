using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerDiscard : MonoBehaviour
{
    CursorControl cursor;
    [SerializeField] PlayerResourceManager m_resource;

    private void Start()
    {
        cursor = GameObject.FindGameObjectWithTag("Cursor").GetComponent<CursorControl>();
        m_resource = FindObjectOfType<PlayerResourceManager>();
    }

    public void removeTower()
    {
        if (cursor.m_currentTower != null)
        {
            cursor.m_currentTower = null;
            cursor.SetMarkerSprite(null);
        }

        if(cursor.m_currentSpike != null)
        {
            cursor.m_currentSpike = null;
            cursor.SetMarkerSprite(null);
        }
    }

    public void deleteTower()
    {
        if (cursor.GetComponent<CursorControl>().m_selectedTower != null)
        {
            m_resource.AddMoney(cursor.GetSelectedTowerScript().m_sellCost);
            Destroy(cursor.m_selectedTower);
            cursor.m_selectedTower = null;
        }
    }
}
