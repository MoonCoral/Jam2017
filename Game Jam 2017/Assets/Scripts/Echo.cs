using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Echo : MonoBehaviour
{

    private ParticleSystem system;
    public List<ParticleCollisionEvent> collisionEvents;

    // Use this for initialization
    void Start () {
        system = GetComponent<ParticleSystem>();
        system.GetComponent<Renderer>().sortingLayerName = "Foreground";
        collisionEvents = new List<ParticleCollisionEvent>();
    }
    
    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<ParticleSystem>().Emit(5000);
        }
    }

    void OnParticleCollision(GameObject other)
    {
        ParticleSystem.Particle[] particles = new ParticleSystem.Particle[system.particleCount];

        if (other.tag == "Enemy")
        {
            //Debug.Log("Enemy");

            int numCollisionEvents = system.GetCollisionEvents(other, collisionEvents);
            int particleCount = system.GetParticles(particles);

            float x = 0;
            float y = 0;

            for (int c = 0; c < numCollisionEvents; c++)
            {
                x += collisionEvents[c].intersection.x;
                y += collisionEvents[c].intersection.y;
            }

            x /= numCollisionEvents;
            y /= numCollisionEvents;

            float xMin = x - 0.40f;
            float xMax = x + 0.40f;

            float yMin = y - 0.40f;
            float yMax = y + 0.40f;


            //Debug.Log("X>>>");
            //Debug.Log(xMax);
            //Debug.Log(xMin);
            //Debug.Log("<<<X");
            //Debug.Log("Y>>>");
            //Debug.Log(yMax);
            //Debug.Log(yMin);
            //Debug.Log("<<<y");

            for (int p = 0; p < particleCount; p++)
            {
                //Debug.Log(particles[p].position);

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

                foreach (var collision in collisionEvents)
                {
                    if (collision.intersection == particles[p].position)
                    {
                        float velfix = 5.0f / collision.velocity.magnitude;
                        particles[p].velocity = collision.velocity;
                        particles[p].velocity.Scale(new Vector3(velfix, velfix));
                        Vector3 fixer = new Vector3(particles[p].velocity.x * 0.075f, particles[p].velocity.y * 0.075f);
                        particles[p].position += fixer;
                    }
                }
            }

        system.SetParticles(particles, particleCount);
        }
    }
}
