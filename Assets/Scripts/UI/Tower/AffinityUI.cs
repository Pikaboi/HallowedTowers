using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AffinityUI : MonoBehaviour
{
    public TDTowerManager m_manager;
    public Image m_image;

    public Sprite m_monster; 
    public Sprite m_soul;
    public Sprite m_magic;
    public Sprite m_undead;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(45.0f, 0.0f, 0.0f);

        switch (m_manager.m_affinity)
        {
            case affinity.Affinity.MONSTER:
                m_image.sprite = m_monster;
                break;
            case affinity.Affinity.MAGIC:
                m_image.sprite = m_magic;
                break;
            case affinity.Affinity.SOUL:
                m_image.sprite = m_soul;
                break;
            case affinity.Affinity.UNDEAD:
                m_image.sprite = m_undead;
                break;
            default:
                break;
        }
    }
}
