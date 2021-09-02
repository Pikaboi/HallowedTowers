using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldCharacter : MonoBehaviour
{
    CharacterController m_Controller;
    [SerializeField] float m_speed;

    enum WeaponType
    {
        UNARMED,
        MELEE,
        RANGE
    };

    [SerializeField] WeaponType m_Equipped;

    // Start is called before the first frame update
    void Start()
    {
        m_Controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(x, 0.0f, y);
        dir = dir.normalized;

        m_Controller.SimpleMove(dir * m_speed);

        transform.forward = dir;
    }

    void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            switch (m_Equipped)
            {
                case WeaponType.UNARMED:
                    break;
                case WeaponType.MELEE:
                    break;
                case WeaponType.RANGE:
                    break;
                default:
                    break;
            }
        }
    }
}
