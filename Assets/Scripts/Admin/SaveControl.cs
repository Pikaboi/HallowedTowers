using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveControl : MonoBehaviour
{
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

    public void LoadGame()
    {
        //FindObjectOfType<WorldCharacter>().DeleteWeaponsforLoad();
        ES3AutoSaveMgr.Current.Load();
        FindObjectOfType<WorldCharacter>().DeleteWeaponsforLoad();
    }
}
