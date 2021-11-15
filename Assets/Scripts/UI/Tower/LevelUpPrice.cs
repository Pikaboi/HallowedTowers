using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpPrice : MonoBehaviour
{
    public TMPro.TMP_Text t;
    // Start is called before the first frame update
    void Start()
    {
        t = GetComponent<TMPro.TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponentInParent<TDTower_LevelUp>().isMax)
        {
            t.text = "Level MAX";
        }
        else
        {
            t.text = "Level Up: " + GetComponentInParent<TDTower_LevelUp>().GetPrice().ToString();
        }
    }
}
