using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrickTreatHouse : MonoBehaviour
{
    [SerializeField] float m_multiplier;
    [SerializeField] float m_baseIncome;

    [SerializeField] float m_value;

    [SerializeField] PlayerResourceManager m_resource;

    [SerializeField] AudioSource m_Collect;

    public TMPro.TMP_Text t;

    public float limit = 10000;

    //bool End = false;
    // Start is called before the first frame update
    void Start()
    {
        m_resource = FindObjectOfType<PlayerResourceManager>();
    }

    // Update is called once per frame
    void Update()
    {
        t.text = m_value.ToString();
    }

    public void UpdateIncome()
    {

        m_value += m_baseIncome * m_multiplier;

        if(m_value > limit)
        {
            m_value = limit;
        }

        m_multiplier += 0.1f;
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.GetComponent<WorldCharacter>() != null)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                m_resource.AddMoney(m_value);
                m_value = 0;
                m_multiplier = 1.0f;
                m_Collect.Play();
            }
        }
    }
}
