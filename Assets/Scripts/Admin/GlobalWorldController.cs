using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;
using UnityEngine.UI;

public class GlobalWorldController : MonoBehaviour
{
    public DensityVolume[] Fogs;
    public WaveCreator[] waveCreators;
    public Image[] skipTravelIcons;

    public SceneControl m_sceneControl;

    [SerializeField] private bool GameOver;

    [SerializeField] RoundPlayButton m_playButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            GameObject[] go = GameObject.FindGameObjectsWithTag("Enemy");

            foreach(GameObject g in go)
            {
                Destroy(g);
            }
        }

        foreach(WaveCreator w in waveCreators)
        {
            if(w.spawnsFinshed == false)
            {
                GameOver = false;
                break;
            }
            GameOver = true;
        }

        if (GameOver)
        {
            m_sceneControl.Win();
        }
    }

    public void UpdateEconomy()
    {
        TrickTreatHouse[] houses = GameObject.FindObjectsOfType<TrickTreatHouse>();

        foreach (TrickTreatHouse t in houses)
        {
            t.UpdateIncome();
        }

        TDTower_SpiderWeb[] webTowers = GameObject.FindObjectsOfType<TDTower_SpiderWeb>();

        foreach (TDTower_SpiderWeb s in webTowers)
        {
            if (s.Path3UG3)
            {
                s.SpiderIncome();
            }
        }
    }

}
