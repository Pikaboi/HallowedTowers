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
    }
}
