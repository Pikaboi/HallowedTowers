using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateWeaponUpgradeMenu : MonoBehaviour
{
    public GameObject m_content;

    public GameObject m_WUGMenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        WeaponEquipButton[] _Equips = m_content.GetComponentsInChildren<WeaponEquipButton>();

        foreach(WeaponEquipButton web in _Equips)
        {
            GameObject wug = Instantiate(m_WUGMenu);
            wug.transform.SetParent(transform, false);
            wug.GetComponent<UpgradeMenuUpdater>().getEquipper(web);
            
        }
    }

    private void OnDisable()
    {
        for(int i = 0; i < m_content.transform.childCount; i++)
        {
            Destroy(m_content.transform.GetChild(i).gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
