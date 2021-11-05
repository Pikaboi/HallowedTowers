using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TDProjectileTank : TDProjectile
{
    //Path 1 manipulates the Peirce Count

    public bool Path2UG1;
    /// <summary>
    /// First Target is dealt double damage if in a Affinity Disadvantage
    /// </summary>

    public bool Path2UG2;
    /// <summary>
    ///  Pushes the first target with the cannon
    /// </summary>

    public bool Path2UG3;
    /// <summary>
    /// Triple Damage against bosses
    /// </summary>

    public bool Path3UG1;
    /// <summary>
    /// Enemies hit are stunned for a short time
    /// </summary>

    public bool Path3UG2;
    /// <summary>
    /// Increased stun for those with disadvantage
    /// </summary>

    public bool Path3UG3;
    /// <summary>
    /// Can now stun those with advantage, but it is weaker
    /// </summary>

    public int m_PeirceCount;
    public int m_MaxPeirce;
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
    }

    public override void OnCollisionEnter(Collision collision)
    {
        //We dont use OnCollisionEnter for peirce so we override the function
    }

    public override void DamageEnemy(float damage, TDEnemy _enemy)
    {
        float trueDamage = damage * AffinityCheck(_enemy.m_affinity) * _enemy.m_debuffMultiplier;

        if(Path2UG1 && AffinityCheck(_enemy.m_affinity) == 1.2f && m_PeirceCount == m_MaxPeirce)
        {
            trueDamage *= 2;
        }

        if (Path2UG2 && m_PeirceCount == m_MaxPeirce)
        {
            _enemy.GetComponent<Rigidbody>().AddForce(transform.forward * m_Speed, ForceMode.Impulse);
        }

        if(Path3UG1 && _enemy.m_StunImmuneTimer < 0 && !_enemy.m_Stunned)
        {
            _enemy.m_Stunned = true;

            if (Path3UG2)
            {
                if (Path3UG3 && AffinityCheck(_enemy.m_affinity) == 0.8f)
                {
                     _enemy.m_StunTimer = 1.0f;
                }
                else if (AffinityCheck(_enemy.m_affinity) == 1.2f)
                {
                    _enemy.m_StunTimer = 4.0f;
                } else
                {
                    _enemy.m_StunTimer = 2.0f;
                }
            } else {
                _enemy.m_StunTimer = 2.0f;
            }
            Debug.Log(_enemy.m_StunTimer);

            _enemy.m_StunImmuneTimer = 5.0f;
        }


        _enemy.m_resource.AddMoney(trueDamage);
        _enemy.m_health -= trueDamage;
        _enemy.m_Damage.Play();
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            DamageEnemy(m_attack, other.gameObject.GetComponent<TDEnemy>());
            m_PeirceCount--;
        }
    }
}
