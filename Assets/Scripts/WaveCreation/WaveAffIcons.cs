using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using affinity;

public class WaveAffIcons : MonoBehaviour
{
    public Sprite m_Monster;
    public Sprite m_Soul;
    public Sprite m_Magic;
    public Sprite m_Undead;

    private SpriteRenderer m_Self;

    public WaveCreator m_wav;
    // Start is called before the first frame update
    void Start()
    {
        m_Self = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetNextAffinity()
    {
        switch (m_wav.GetWaveAffinity())
        {
            case Affinity.MONSTER:
                m_Self.sprite = m_Monster;
                break;
            case Affinity.MAGIC:
                m_Self.sprite = m_Magic;
                break;
            case Affinity.SOUL:
                m_Self.sprite = m_Soul;
                break;
            case Affinity.UNDEAD:
                m_Self.sprite = m_Undead;
                break;
            default:
                m_Self.sprite = null;
                break;
        }

        if (m_wav.EmptyWaveAffinity())
        {
            m_Self.enabled = false;
        } else
        {
            m_Self.enabled = true;
        }
    }
}
