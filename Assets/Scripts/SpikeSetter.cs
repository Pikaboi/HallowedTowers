using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeSetter : MonoBehaviour
{
    public GameObject Spike;
    GameObject cursor;

    private void Start()
    {
        cursor = GameObject.FindGameObjectWithTag("Cursor");
    }

    public void SetTower()
    {
        cursor.GetComponent<CursorControl>().m_currentSpike = Spike;
        cursor.GetComponent<CursorControl>().m_currentTower = null;
    }
}
