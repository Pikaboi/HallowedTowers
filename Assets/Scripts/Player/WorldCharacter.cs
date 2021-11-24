using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldCharacter : MonoBehaviour
{
    CharacterController m_Controller;
    [SerializeField] float m_speed;
    public float m_health;
    [SerializeField] private float m_maxHealth;

    public float m_attackTime;
    float m_maxat;
    public bool m_attack = false;
    public Animator m_anim;

    public float maxRespawnTimer = 5.0f;
    private float respawnTimer;

    public GameObject SpawnPoint;

    public float m_maxPassiveAggroTimer;
    private float m_passiveAggroTimer;

    bool dashing = false;

    public ParticleSystem m_BuffParticle;

    public AudioSource m_weaponSFX;
    public AudioSource m_oof;
    public AudioSource m_dead;
    public AudioSource m_respawn;

    [SerializeField] private LayerMask m_mask;
    [SerializeField] private MapButton m_map;
    [SerializeField] private MapButton m_inventory;

    enum WeaponType
    {
        UNARMED,
        MELEE,
        RANGE
    };

    [SerializeField] WeaponType m_Equipped;
    [SerializeField] GameObject m_Weapon;
    [SerializeField] public PlayerWeapon m_WeaponStats;

    // Start is called before the first frame update
    void Start()
    {
        respawnTimer = maxRespawnTimer;
        m_passiveAggroTimer = m_maxPassiveAggroTimer;
        m_health = m_maxHealth;
        m_Controller = GetComponent<CharacterController>();
        if (m_Weapon != null)
        {
            m_WeaponStats = m_Weapon.GetComponent<PlayerWeapon>();

            if (m_WeaponStats.isMelee)
            {
                m_Weapon.SetActive(false);
            }
        }
        m_maxat = m_attackTime;

        if (m_Weapon != null)
        {
            SpawnWeapon(m_Weapon, new Vector3(90, 270, 0));
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.M))
        {
            m_map.OnClick();
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            m_inventory.OnClick();
        }

        if (m_WeaponStats.m_atkBuff != 0 && m_BuffParticle.isStopped)
        {
            m_BuffParticle.Play();
        }
        else if (m_WeaponStats.m_atkBuff == 0)
        {
            m_BuffParticle.Stop();
        }

        if (m_health > 0)
        {
            AggroCheck();
            WeaponStatsCheck();
            Movement();
            Attack();
        } else
        {
            respawnTimer -= Time.deltaTime;

            if(respawnTimer <= 0)
            {
                Respawn();
            }
        }
    }

    void AggroCheck()
    {
        m_passiveAggroTimer -= Time.deltaTime;
        int aggroCount = 0;

        if (m_passiveAggroTimer < 0)
        {
            Collider[] g = Physics.OverlapSphere(transform.position, 5.0f, m_mask);

            foreach (Collider go in g)
            {
                if (go.gameObject.GetComponent<TDEnemy>() != null && aggroCount <= 2)
                {
                    go.gameObject.GetComponent<TDEnemy>().AggroRoll();

                    if (go.gameObject.GetComponent<TDEnemy>().aggro)
                    {
                        aggroCount++;
                    }
                }
            }

            m_passiveAggroTimer = m_maxPassiveAggroTimer;
        }
    }

    void Respawn()
    {
        m_respawn.Play();
        m_health = m_maxHealth;
        transform.position = SpawnPoint.transform.position;
        respawnTimer = maxRespawnTimer;
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
            m_Weapon.SetActive(true);
        }
    }

    void Movement()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Vector3 dir = new Vector3(x, 0.0f, y);
        dir = dir.normalized;

        if (Input.GetKeyDown(KeyCode.E))
        {
            m_Controller.Move(dir * m_speed * 10.0f * Time.deltaTime);
            dashing = true;
        }
        else
        {
            m_Controller.SimpleMove(dir * m_speed);
            dashing = false;
        }

        if (dir != Vector3.zero)
        {
            transform.forward = dir;
            m_anim.SetBool("Moving", true);
        } else
        {
            m_anim.SetBool("Moving", false);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<TDEnemy>() != null && !dashing)
        {
            if(collision.gameObject.GetComponent<TDEnemy>().m_targetState == TDEnemy.TargetState.PLAYER)
            {
                m_health -= collision.gameObject.GetComponent<TDEnemy>().m_attackPower;

                if(m_health <= 0)
                {
                    m_dead.Play();
                } else
                {
                    m_oof.Play();
                }
            }
        }
    }

    void Attack()
    {
        if (m_attack)
        {
            m_attackTime -= Time.deltaTime;

            if (m_attackTime <= 0)
            {
                if (m_WeaponStats.isMelee)
                {
                    m_Weapon.SetActive(false);
                }
                m_attack = false;
                m_attackTime = m_maxat;
            }
        }
        else
        {

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (m_anim != null)
                {
                    m_anim.SetTrigger("Attack");
                }
                switch (m_Equipped)
                {
                    case WeaponType.UNARMED:
                        //Do nothing
                        break;
                    case WeaponType.MELEE:
                        //Weapon appears and attacks in front
                        m_Weapon.SetActive(true);
                        m_attack = true;

                        if (m_weaponSFX.clip != null)
                        {
                            m_weaponSFX.Play();
                        }

                        break;
                    case WeaponType.RANGE:
                        if (m_weaponSFX != null)
                        {
                            m_weaponSFX.Play();
                        }
                        if(m_WeaponStats.m_particle != null)
                        {
                            m_WeaponStats.m_particle.Play();
                        }

                        if (m_WeaponStats.Bullet != null)
                        {
                            GameObject b = Instantiate(m_WeaponStats.Bullet, m_WeaponStats.shootpos.position, transform.rotation);

                            //We are using the same framework as the tower projectiles
                            b.GetComponent<TDProjectile>().InheritFromTower(m_WeaponStats.m_BulletRange, m_WeaponStats.m_Attack, m_WeaponStats.gameObject, m_WeaponStats.m_Affinity);
                        }
                        //Shoot a projectile
                        break;
                    default:
                        break;
                }
            }
        }
    }

    public void SpawnWeapon(GameObject _weapon, Vector3 m_rot)
    {
        if (m_Weapon != null)
        {
            Destroy(m_Weapon);
        }
        m_Weapon = null;
        m_Weapon = Instantiate(_weapon, transform.position + transform.forward, Quaternion.Euler(m_rot.x, m_rot.y + transform.rotation.eulerAngles.y, m_rot.z - transform.rotation.eulerAngles.z));
        m_Weapon.transform.parent = transform;
        m_WeaponStats = m_Weapon.GetComponent<PlayerWeapon>();
        m_weaponSFX.clip = m_WeaponStats.m_audioClip;
        m_Weapon.SetActive(false);
    }

    public float GetMaxHealth() {
        return m_maxHealth;
    }
}
