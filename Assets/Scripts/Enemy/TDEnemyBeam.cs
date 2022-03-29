using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TDEnemyBeam : TDEnemyProjectile
{
    public ParticleSystem m_particle;
    public List<ParticleCollisionEvent> collisionEvents = new List<ParticleCollisionEvent>();

    public override void Start()
    {
        m_particle.Play();
        ogPos = transform.position;
    }

    // Update is called once per frame
    public override void Update()
    {
        if (m_particle.isStopped)
        {
            Destroy(this.gameObject);
        }
    }

    void OnParticleCollision(GameObject other)
    {
        int numCollisionEvents = m_particle.GetCollisionEvents(other, collisionEvents);

        foreach(ParticleCollisionEvent e in collisionEvents)
        {
            if(other.gameObject.GetComponent<WorldCharacter>() != null)
            {
                other.gameObject.GetComponent<WorldCharacter>().ParticleDamage(m_attack);
            }
        }
    }
}
