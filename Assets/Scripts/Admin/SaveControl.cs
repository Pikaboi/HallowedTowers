using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveControl : MonoBehaviour
{
    public List<GameObject> m_towers = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SaveGame()
    {
        TDTowerManager[] towers = FindObjectsOfType<TDTowerManager>();

        foreach(TDTowerManager tower in towers)
        {
            m_towers.Add(tower.gameObject);
        }

        ES3.Save("playerTowers", m_towers);
    }

    public void LoadGame()
    {
        m_towers = (List<GameObject>)ES3.Load("playerTowers");
    }
}
