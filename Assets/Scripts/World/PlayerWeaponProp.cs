using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponProp : MonoBehaviour
{
    public GameObject m_RealWeapon;
    [SerializeField] WorldCharacter m_Char;
    bool inzone;
    public Vector3 m_WeaponRot;
    public AudioSource m_Equip;

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
                m_Char.SpawnWeapon(m_RealWeapon, m_WeaponRot);
                m_Equip.Play();
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
        if(other.gameObject == m_Char.gameObject && other.gameObject.GetComponent<WorldCharacter>() != null)
        {
            Debug.Log("ah");
            m_Char = null;
            inzone = false;
        }
    }
}
