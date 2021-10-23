using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Add the custom affinity namespace
using Affinity = affinity.Affinity;

public class PlayerWeapon : MonoBehaviour
{
    public float m_Attack;
    public float m_atkBuff;
    public bool isMelee; //True = Melee, False = Range
    //Only add this if its a Ranged weapon
    public GameObject Bullet;
    public float m_BulletRange;
    public Affinity m_Affinity;

    public virtual void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<TDEnemy>().DamageEnemy(m_Attack + (m_Attack * m_atkBuff), m_Affinity);
        }
    }

    public void Buff(float _buff, Affinity _affinity)
    {
        float mult = 1.0f;
        if(_affinity == m_Affinity)
        {
            mult = 1.2f;
        }

        if(_buff * mult > m_atkBuff)
        {
            m_atkBuff = _buff * mult;
        }
    }

    public void Debuff()
    {
        m_atkBuff = 0;
    }


}
