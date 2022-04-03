using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopSpeechBubble : MonoBehaviour
{
    public Sprite[] m_sprites;
    public Sprite m_base;

    private Image m_img;
    // Start is called before the first frame update
    void Start()
    {
        m_img = GetComponent<Image>();
    }

    private void OnEnable()
    {
        m_img.sprite = m_base;
    }

    public void OnPurchase()
    {
        int rand = Random.Range(0, m_sprites.Length);
        m_img.sprite = m_sprites[rand];
    }
}
