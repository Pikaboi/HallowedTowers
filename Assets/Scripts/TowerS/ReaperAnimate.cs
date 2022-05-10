using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReaperAnimate : MonoBehaviour
{
    [SerializeField] private TDTowerReaper m_tower;
    [SerializeField] private TDTower_ReaperMelee m_towerMelee;
    [SerializeField] private Animator m_anim;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        m_tower = transform.parent.GetComponent<TDTowerManager>().m_child.GetComponent<TDTowerReaper>();
        m_towerMelee = transform.parent.GetComponent<TDTowerManager>().m_child.GetComponent<TDTower>().GetComponentInChildren<TDTower_ReaperMelee>();

        if (m_tower != null)
        {
            if (m_tower.shoot)
            {
                m_anim.SetTrigger("Attack");
            }
        }

        if (m_towerMelee != null)
        {
            if (m_towerMelee.shoot)
            {
                m_anim.SetTrigger("Attack");
            }
        }
    }
}
