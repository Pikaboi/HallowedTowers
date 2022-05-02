using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class VolumeSlider : MonoBehaviour
{
    public string m_mixerType;

    // Start is called before the first frame update
    void Start()
    {
        float val = PlayerPrefs.GetFloat(m_mixerType);
        GetComponent<UnityEngine.UI.Slider>().value = val;
    }
}
