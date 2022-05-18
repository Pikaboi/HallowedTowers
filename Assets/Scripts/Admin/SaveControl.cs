using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveControl : MonoBehaviour
{
    public InventoryAdd m_Adder;
    public SceneControl m_scenecontrol;
    // Start is called before the first frame update
    void Start()
    {
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

    public void LoadGame()
    {
        //FindObjectOfType<WorldCharacter>().DeleteWeaponsforLoad();
        //m_Adder.RemoveInventoryOnLoad();
        TDTowerManager[] managers = FindObjectsOfType<TDTowerManager>();

        foreach (TDTowerManager m in managers)
        {
            if (m.saved == false)
            {
                Destroy(m.gameObject);
            }
        }

        ES3AutoSaveMgr.Current.Load();

        TDTowerUpgrade[] ugs = FindObjectsOfType<TDTowerUpgrade>();

        foreach(TDTowerUpgrade u in ugs)
        {
            u.Start();
        }

        FindObjectOfType<WorldCharacter>().DeleteWeaponsforLoad();
        managers = FindObjectsOfType<TDTowerManager>();

        foreach(TDTowerManager m in managers)
        {
            m.RemoveOtherTowers();
        }
    }
}
