using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialScroll : MonoBehaviour
{

    public int childID;
    public int pageID = 0;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < transform.parent.childCount; i++)
        {
            if(transform.parent.GetChild(i).gameObject == this)
            {
                childID = i;
                break;
            }
        }

        for(int i = 0; i < gameObject.transform.childCount; i++)
        {
            if(i == 0)
            {
                transform.GetChild(i).gameObject.SetActive(true);
            } else
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PageForward()
    {
        transform.GetChild(pageID).gameObject.SetActive(false);
        pageID++;
        transform.GetChild(pageID).gameObject.SetActive(true);
    }

    public void PageBack()
    {
        transform.GetChild(pageID).gameObject.SetActive(false);
        pageID--;
        transform.GetChild(pageID).gameObject.SetActive(true);
    }

    public void Close()
    {
        transform.parent.GetComponent<TutorialControl>().CloseTutorial(childID);
    }
}
