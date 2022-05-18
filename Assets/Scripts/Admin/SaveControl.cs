using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveControl : MonoBehaviour
{
    public InventoryAdd m_Adder;
    public SceneControl m_scenecontrol;
    public GameObject m_saveBool;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        SaveBoolean save = FindObjectOfType<SaveBoolean>();

        if(save != null)
        {
            if (save.load)
            {
                LoadGame();
            }
            Destroy(save.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SaveGame()
    {
        TDTowerManager[] managers = FindObjectsOfType<TDTowerManager>();

        foreach (TDTowerManager m in managers)
        {
            m.saved = true;
        }

        ES3AutoSaveMgr.Current.Save();
    }

    public void SaveAndQuit()
    {
        TDTowerManager[] managers = FindObjectsOfType<TDTowerManager>();

        foreach (TDTowerManager m in managers)
        {
            m.saved = true;
        }

        ES3AutoSaveMgr.Current.Save();
        m_scenecontrol.Title();
    }

    public void ReloadScene()
    {
        Instantiate(m_saveBool);
        m_saveBool.GetComponent<SaveBoolean>().load = true;

        m_scenecontrol.Game();
    }

    public void LoadGame()
    {
        ES3AutoSaveMgr.Current.Load();
    }
}
