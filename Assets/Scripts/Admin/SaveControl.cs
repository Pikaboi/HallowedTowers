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
        ES3AutoSaveMgr.Current.Save();
    }

    public void SaveAndQuit()
    {
        ES3AutoSaveMgr.Current.Save();
        m_scenecontrol.Title();
    }

    public void LoadGame()
    {
        //FindObjectOfType<WorldCharacter>().DeleteWeaponsforLoad();
        //m_Adder.RemoveInventoryOnLoad();
        ES3AutoSaveMgr.Current.Load();
        FindObjectOfType<WorldCharacter>().DeleteWeaponsforLoad();
        TDTowerManager[] managers = FindObjectsOfType<TDTowerManager>();

        foreach(TDTowerManager m in managers)
        {
            m.RemoveOtherTowers();
        }
    }
}
