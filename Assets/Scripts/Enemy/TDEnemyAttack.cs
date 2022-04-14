using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TDEnemyAttack : MonoBehaviour
{
    // this is attached to colliders that determine the hitbox of attacks
    public TDEnemy m_enemy;
    public float m_attack;
    public CapsuleCollider m_cc;
    void Start()
    {
        m_cc = GetComponent<CapsuleCollider>();
        m_attack = m_enemy.m_playerAttackPower;
        m_cc.enabled = false;
    }
}
