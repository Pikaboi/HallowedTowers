using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundPlayButton : MonoBehaviour
{
    Button m_button;
    Image m_Image;
    //[SerializeField] TMPro.TMP_Text m_Text;
    public WaveCreator[] m_waveCreators;

    bool m_roundOver;

    public GlobalWorldController m_global;

    // Start is called before the first frame update
    void Start()
    {
        m_button = GetComponent<Button>();
        m_Image = GetComponent<Image>();
    }

    //void Awake()
    //{
    //    m_button.onClick.AddListener(StartLevel);
   // }

    //Handle the onClick event
    void StartLevel()
    {
        foreach(WaveCreator w in m_waveCreators)
        {
            w.StartWave();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        m_button.onClick.AddListener(StartLevel);

        GameObject[] go = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (WaveCreator w in m_waveCreators)
        {
            if (w.WavePlaying)
            {
                m_roundOver = false;
                break;
            }
            m_roundOver = true;
        }

        if(go.Length == 0 && m_roundOver)
        {
            if (!m_Image.enabled)
            {
                m_global.UpdateEconomy();
            }

            m_Image.enabled = true;
            m_button.enabled = true;
            //m_Text.enabled = true;
        }
        else
        {
            m_Image.enabled = false;
            m_button.enabled = false;
            //m_Text.enabled = false;
        }
    }
}
