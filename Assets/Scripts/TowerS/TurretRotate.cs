using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretRotate : MonoBehaviour
{
    [SerializeField] private TDTower m_tower;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        m_tower = transform.parent.parent.GetComponent<TDTowerManager>().m_child.GetComponent<TDTower>();

        Quaternion Rotation = Quaternion.LookRotation(m_tower.rotaterLookAt);
        transform.rotation = Quaternion.Slerp(transform.rotation, Rotation, 1);
    }
}
