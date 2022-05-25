using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialCheckInventory : MonoBehaviour
{
    private bool callTutorial = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void playTutorial()
    {
        if (!callTutorial)
        {
            FindObjectOfType<TutorialControl>().ActivateTutorial(0);
            callTutorial = true;
        }
    }
}
