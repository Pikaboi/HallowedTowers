using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AffinityPriceTag : MonoBehaviour
{
    [SerializeField] ChangeAffinity[] m_affinityButtons;
    TMPro.TMP_Text t;

    [SerializeField] float m_updatedUGPrice;
    // Start is called before the first frame update
    void Start()
    {
        t = GetComponent<TMPro.TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        t.text = "Affinity Change: " + m_affinityButtons[0].m_upgradePrice.ToString();
    }

    public void UpdatePrice()
    {
        foreach(ChangeAffinity g in m_affinityButtons)
        {
            g.m_upgradePrice = m_updatedUGPrice;
        }
    }

}
