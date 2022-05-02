using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioSettings : MonoBehaviour
{
    public AudioMixer m_AudioMixer;
    public float sfx;
    public float bgm;
    public float master;
    // Start is called before the first frame update
    public void Start()
    {
        sfx = PlayerPrefs.GetFloat("SFX");
        bgm = PlayerPrefs.GetFloat("BGM");
        master = PlayerPrefs.GetFloat("master");
        m_AudioMixer.SetFloat("MasterVol", master);
        m_AudioMixer.SetFloat("BGMVol", bgm);
        m_AudioMixer.SetFloat("SFXVol", sfx);
    }

    public void SetMasterVol(float _vol)
    {
        m_AudioMixer.SetFloat("MasterVol", Mathf.Log10(_vol) * 20);
        master = _vol;
        PlayerPrefs.SetFloat("master", master);
    }


    public void SetMusicVol(float _vol)
    {
        m_AudioMixer.SetFloat("BGMVol", _vol);
        bgm = _vol;
        PlayerPrefs.SetFloat("BGM", bgm);
    }

    public void SetSFXVol(float _vol)
    {
        m_AudioMixer.SetFloat("SFXVol", _vol);
        sfx = _vol;
        PlayerPrefs.SetFloat("SFX", sfx);
    }
}
