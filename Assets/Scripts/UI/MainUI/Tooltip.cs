using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Tooltip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Button m_button;
    public Image m_tooltip;
    TMPro.TMP_Text m_tooltipText;
    // Start is called before the first frame update
    void Start()
    {
        m_button = GetComponent<Button>();
        m_tooltip.enabled = false;
        m_tooltipText = m_tooltip.GetComponentInChildren<TMPro.TMP_Text>();
        m_tooltipText.enabled = false;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        m_tooltip.enabled = true;
        m_tooltipText.enabled = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        m_tooltip.enabled = false;
        m_tooltipText.enabled = false;
    }

}
