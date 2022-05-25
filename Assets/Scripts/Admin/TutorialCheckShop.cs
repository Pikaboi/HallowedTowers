using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialCheckShop : MonoBehaviour
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
            FindObjectOfType<TutorialControl>().ActivateTutorial(6);

            TutorialCheckShop[] checks = FindObjectsOfType<TutorialCheckShop>(true);
            
            foreach (TutorialCheckShop check in checks)
            {
                check.callTutorial = true;
            }
        }
    }
}
