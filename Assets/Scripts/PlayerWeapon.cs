using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    public float m_Attack;
    public bool isMelee; //True = Melee, False = Range
    //Only add this if its a Ranged weapon
    public GameObject Bullet;
    public float m_BulletRange;
}
