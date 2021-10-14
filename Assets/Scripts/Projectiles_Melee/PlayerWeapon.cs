using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Add the custom affinity namespace
using Affinity = affinity.Affinity;

public class PlayerWeapon : MonoBehaviour
{
    public float m_Attack;
    public bool isMelee; //True = Melee, False = Range
    //Only add this if its a Ranged weapon
    public GameObject Bullet;
    public float m_BulletRange;
    public Affinity m_Affinity;

    public virtual void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<TDEnemy>().DamageEnemy(m_Attack, m_Affinity);
        }
    }
}
