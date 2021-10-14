using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;
using UnityEngine.UI;

public class GlobalWorldController : MonoBehaviour
{
    public struct fogWavePair
    {
        public DensityVolume vol;
        public WaveCreator wav;
        public Image skip;
    }

    public DensityVolume[] Fogs;
    public WaveCreator[] waveCreators;
    public Image[] skipTravelIcons;

    public SceneControl m_sceneControl;

    public WaveCreator m_lastWave;

    [SerializeField] RoundPlayButton m_playButton;

    public List<fogWavePair> pairs = new List<fogWavePair>();
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < Fogs.Length; i++)
        {
            fogWavePair pair = MakePair(Fogs[i], waveCreators[i], skipTravelIcons[i]);
            pairs.Add(pair);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (pairs.Count != 0)
        {
            if (pairs[0].wav.waveIndex == pairs[0].wav.m_waves.Length)
            {
                pairs[0].vol.gameObject.SetActive(false);
                if (pairs[0].skip != null)
                {
                    pairs[0].skip.enabled = true;
                }
                pairs[0].wav.enabled = false;

                pairs.Remove(pairs[0]);

                m_playButton.m_waveCreator = pairs[0].wav;
            }
        }
        else if (pairs.Count == 0)
        {
            m_playButton.m_waveCreator = m_lastWave;
        }


        if(m_lastWave.waveIndex == m_lastWave.m_waves.Length)
        {
            m_sceneControl.Win();
        }
    }

    fogWavePair MakePair(DensityVolume _f, WaveCreator _w, Image _s)
    {
        fogWavePair Pair;
        Pair.vol = _f;
        Pair.wav = _w;
        Pair.skip = _s;
        return Pair;
    }
}
