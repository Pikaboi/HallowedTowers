using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void GamePause()
    {
        if(Time.timeScale == 1)
        {
            Time.timeScale = 0;
        } else
        {
            Time.timeScale = 1;
        }
    }
}
