using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponProp : MonoBehaviour
{
    public GameObject m_RealWeapon;
    [SerializeField] WorldCharacter m_Char;
    bool inzone;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (inzone)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                m_Char.SpawnWeapon(m_RealWeapon);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<WorldCharacter>() != null)
        {
            m_Char = other.gameObject.GetComponent<WorldCharacter>();
            inzone = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject == m_Char)
        {
            Debug.Log("ah");
            m_Char = null;
            inzone = false;
        }
    }
}
