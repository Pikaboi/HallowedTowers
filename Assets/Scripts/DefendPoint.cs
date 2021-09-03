using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefendPoint : MonoBehaviour
{
    [SerializeField] private PlayerResourceManager m_resource;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            m_resource.DamageWorldHealth(other.GetComponent<TDEnemy>().m_attackPower);
            Destroy(other.gameObject);
        }
    }
}
