using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetIncomMoney : MonoBehaviour
{
    [SerializeField] private TrickTreatHouse m_income;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<TMPro.TMP_Text>().text = m_income.t.text;
    }
}
