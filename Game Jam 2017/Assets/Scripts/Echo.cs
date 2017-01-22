using UnityEngine;
using System.Collections.Generic;

public class Echo : MonoBehaviour
{
    public int Emission = 1000;
    public float Radius = 0.40f;

    private ParticleSystem system;
    public List<ParticleCollisionEvent> collisionEvents;

    // Use this for initialization
    void Start () {
        system = GetComponent<ParticleSystem>();
        system.GetComponent<Renderer>().sortingLayerName = "Foreground";
        collisionEvents = new List<ParticleCollisionEvent>();
        system.maxParticles = Emission;
    }
    
    // Update is called once per frame
    void Update () {
        if (GetComponent<ParticleSystem>().particleCount < Emission/2)
        {
            GetComponentInParent<AudioSource>().Play();
            GetComponent<ParticleSystem>().Emit(Emission);
        }
    }

    void OnParticleCollision(GameObject other)
    {
        ParticleSystem.Particle[] particles = new ParticleSystem.Particle[system.particleCount];

        if (other.tag == "Enemy")
        {
            int numCollisionEvents = system.GetCollisionEvents(other, collisionEvents);
            int particleCount = system.GetParticles(particles);

            Vector3 enemy = other.transform.position;
            enemy = system.transform.InverseTransformPoint(enemy);

            //Debug.Log("Enemy");
            //Debug.Log(enemy);

            float xMin = enemy.x - Radius;
            float xMax = enemy.x + Radius;

            float yMin = enemy.y - Radius;
            float yMax = enemy.y + Radius;

            for (int p = 0; p < particleCount; p++)
            {
                if (particles[p].velocity.magnitude > 0.1)
                {
                    continue;
                }

                if (particles[p].position.x < xMin)
                {
                    continue;
                }
                if (particles[p].position.x > xMax)
                {
                    continue;
                }
                if (particles[p].position.y < yMin)
                {
                    continue;
                }
                if (particles[p].position.y > yMax)
                {
                    continue;
                }

                particles[p].startColor = new Color32(0xFF, 0, 0, 0xFF);

                Vector3 vel = particles[p].position;
                vel.Normalize();
                //Debug.Log(vel.magnitude);
                //vel.Scale(new Vector3(2.5f, 2.5f));

                //Debug.Log(vel.magnitude);

                particles[p].velocity = vel;
                //Debug.Log(particles[p].velocity.magnitude);

                Vector3 fixer = new Vector3(vel.x * Time.deltaTime,vel.y * Time.deltaTime);
                fixer += particles[p].position;

                particles[p].position = fixer;
            }

        system.SetParticles(particles, particleCount);
        }
    }
}
