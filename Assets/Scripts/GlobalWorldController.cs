using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;

public class GlobalWorldController : MonoBehaviour
{
    public struct fogWavePair
    {
        public DensityVolume vol;
        public WaveCreator wav;
    }

    public DensityVolume[] Fogs;
    public WaveCreator[] waveCreators;

    public List<fogWavePair> pairs;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < Fogs.Length; i++)
        {
            pairs.Add(MakePair(Fogs[i], waveCreators[i]));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(pairs[0].wav.waveIndex > pairs[0].wav.m_waves.Length)
        {
            pairs[0].vol.enabled = false;
            pairs[0].wav.enabled = false;

            pairs.Remove(pairs[0]);
        }
    }

    fogWavePair MakePair(DensityVolume _f, WaveCreator _w)
    {
        fogWavePair Pair;
        Pair.vol = _f;
        Pair.wav = _w;
        return Pair;
    }
}
