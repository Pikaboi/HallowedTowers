using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSelector : MonoBehaviour
{
    public GameObject Tower;
    GameObject cursor;

    private void Start()
    {
        cursor = GameObject.FindGameObjectWithTag("Cursor");
    }

    public void SetTower()
    {
        cursor.GetComponent<CursorControl>().m_currentTower = Tower;
    }
}
