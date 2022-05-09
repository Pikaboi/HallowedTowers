using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KrakenAnimate : MonoBehaviour
{
    [SerializeField] private TDTower_Kraken m_tower;
    [SerializeField] private Animator m_anim;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        m_tower = transform.parent.parent.GetComponent<TDTowerManager>().m_child.GetComponent<TDTower_Kraken>();

        if(m_tower.shoot)
        {
            m_anim.SetTrigger("Attack");
        }
    }
}
