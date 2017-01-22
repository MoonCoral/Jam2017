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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<ParticleSystem>().Emit(Emission);
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

            x = Mathf.Round(x);
            y = Mathf.Round(y);

            //Vector3 w =  transform.TransformPoint(new Vector3(x, y));
            //x = w.x;
            //y = w.y;

            float xMin = x - Radius;
            float xMax = x + Radius;

            float yMin = y - Radius;
            float yMax = y + Radius;

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
                        float velfix = 2.5f / collision.velocity.magnitude;
                        particles[p].velocity = collision.velocity;
                        particles[p].velocity.Normalize();
                        particles[p].velocity.Scale(new Vector3(velfix, velfix));
                        Vector3 fixer = new Vector3(particles[p].velocity.x * Time.deltaTime, particles[p].velocity.y * Time.deltaTime);
                        particles[p].position += fixer;
                    }
                }
            }

        system.SetParticles(particles, particleCount);
        }
    }
}
