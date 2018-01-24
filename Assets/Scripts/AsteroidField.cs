using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AsteroidField : MonoBehaviour
{


    private Transform tx;
    private ParticleSystem.Particle[] points;

    public int asteroidMax = 100;
    public float asteroidSize = 1;
    public float asteroidDistance = 10;
    private float asteroidClipDistance = 0;
    private float asteroidDistanceSqr;
    private float asteroidClipDistanceSqr;


    // Use this for initialization
    void Start()
    {
        tx = transform;
        asteroidDistanceSqr = asteroidDistance * asteroidDistance;
        asteroidClipDistanceSqr = asteroidClipDistance * asteroidClipDistance;
    }


    private void CreateAsteroids()
    {
        points = new ParticleSystem.Particle[asteroidMax];

        for (int i = 0; i < asteroidMax; i++)
        {
            points[i].position = Random.insideUnitSphere * asteroidDistance + tx.position;
            points[i].color = new Color(1, 1, 1, 1);
            points[i].size = asteroidSize;
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (points == null) CreateAsteroids();

        for (int i = 0; i < asteroidMax; i++)
        {

            if ((points[i].position - tx.position).sqrMagnitude > asteroidDistanceSqr)
            {
                points[i].position = Random.insideUnitSphere.normalized * asteroidDistance + tx.position;
            }


        }



        // older versions of Unity
        // particleSystem.SetParticles ( points, points.Length );
        // Unity 5.4+ and probably some sooner versions
        GetComponent<ParticleSystem>().SetParticles(points, points.Length);

    }
}