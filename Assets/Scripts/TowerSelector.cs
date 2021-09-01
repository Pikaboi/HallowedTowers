using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSelector : MonoBehaviour
{
    public GameObject Tower;

    public void SetTower()
    {
        GameObject cursor = GameObject.FindGameObjectWithTag("Cursor");

        cursor.GetComponent<CursorControl>().m_currentTower = Tower;
    }
}
