using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class towerspawn : MonoBehaviour
{
    public GameObject tower1;
    public GameObject tower2;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<WorldCharacter>() != null)
        {
            GetComponent<AudioSource>().Play();
            tower1.SetActive(true);
            tower1.GetComponent<TDTowerManager>().m_UGParticle.Play();
            tower2.SetActive(true);
            tower2.GetComponent<TDTowerManager>().m_UGParticle.Play();
        }
    }
}
