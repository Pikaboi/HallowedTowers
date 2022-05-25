using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialControl : MonoBehaviour
{
    [SerializeField] GameObject[] m_Tutorials;
    // Start is called before the first frame update
    void Start()
    {
        /*GetComponent<UnityEngine.UI.Image>().enabled = false;

        foreach(GameObject tutorial in m_Tutorials)
        {
            tutorial.SetActive(false);
        }*/
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ActivateTutorial(int _tutorialID)
    {
        GetComponent<UnityEngine.UI.Image>().enabled = true;
        m_Tutorials[_tutorialID].SetActive(true);
        Time.timeScale = 0;
    }

    public void CloseTutorial(int _tutorialID)
    {
        GetComponent<UnityEngine.UI.Image>().enabled = false;
        Time.timeScale = 1;
    }
}
