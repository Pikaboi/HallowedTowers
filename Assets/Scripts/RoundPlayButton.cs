using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundPlayButton : MonoBehaviour
{
    Button m_button;
    Image m_Image;
    [SerializeField] TMPro.TMP_Text m_Text;
    public WaveCreator m_waveCreator;
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
        m_waveCreator.StartWave();
    }

    // Update is called once per frame
    void Update()
    {
        m_button.onClick.AddListener(StartLevel);

        GameObject[] go = GameObject.FindGameObjectsWithTag("Enemy");

        if(go.Length == 0 && !m_waveCreator.WavePlaying)
        {
            m_Image.enabled = true;
            m_button.enabled = true;
            m_Text.enabled = true;
        }
        else
        {
            m_Image.enabled = false;
            m_button.enabled = false;
            m_Text.enabled = false;
        }
    }
}
