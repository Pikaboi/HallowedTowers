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

    public WaveCreator m_lastWave;

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
    }

}
