using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldCharacter : MonoBehaviour
{
    CharacterController m_Controller;
    [SerializeField] float m_speed;

    public float m_attackTime = 0.2f;
    public bool m_attack = false;

    enum WeaponType
    {
        UNARMED,
        MELEE,
        RANGE
    };

    [SerializeField] WeaponType m_Equipped;
    [SerializeField] GameObject m_Weapon;
    [SerializeField] PlayerWeapon m_WeaponStats;

    // Start is called before the first frame update
    void Start()
    {
        m_Controller = GetComponent<CharacterController>();
        if (m_Weapon != null)
        {
            m_WeaponStats = m_Weapon.GetComponent<PlayerWeapon>();
        }

        m_Weapon.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        WeaponStatsCheck();
        Movement();
        Attack();
    }

    void WeaponStatsCheck()
    {
        if(m_Weapon == null)
        {
            m_Equipped = WeaponType.UNARMED;
        } else if (m_WeaponStats.isMelee)
        {
            m_Equipped = WeaponType.MELEE;
        } else
        {
            m_Equipped = WeaponType.RANGE;
        }
    }

    void Movement()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Vector3 dir = new Vector3(x, 0.0f, y);
        dir = dir.normalized;

        m_Controller.SimpleMove(dir * m_speed);

        if (dir != Vector3.zero)
        {
            transform.forward = dir;
        }
    }

    void Attack()
    {
        if (m_attack)
        {
            m_attackTime -= Time.deltaTime;

            if (m_attackTime <= 0)
            {
                m_Weapon.SetActive(false);
                m_attack = false;
                m_attackTime = 0.2f;
            }
        }
        else
        {

            if (Input.GetKeyDown(KeyCode.Space))
            {
                switch (m_Equipped)
                {
                    case WeaponType.UNARMED:
                        //Do nothing
                        break;
                    case WeaponType.MELEE:
                        //Weapon appears and attacks in front
                        m_Weapon.SetActive(true);
                        m_attack = true;
                        break;
                    case WeaponType.RANGE:
                        //Shoot a projectile
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
