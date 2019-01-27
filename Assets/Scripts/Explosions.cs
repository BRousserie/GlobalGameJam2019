using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosions : MonoBehaviour
{
    public static Explosions instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);
    }

    public GameObject[] explosionsAlien;
    public GameObject[] explosionsBatiment;
    int currentAlien = 0;
    int currentBatiment = 0;

    public void spawnParticleAlien(Vector3 position)
    {
        explosionsAlien[currentAlien].gameObject.transform.position = position;
        ParticleSystem[] particles = explosionsAlien[currentAlien].GetComponentsInChildren<ParticleSystem>();

        foreach (ParticleSystem particle in particles)
        {
            particle.Play();
        }

        currentAlien++;
        if (currentAlien > explosionsAlien.Length - 1)
            currentAlien = 0;
    }
    public void spawnParticleBatiment(Vector3 position)
    {
        explosionsBatiment[currentBatiment].gameObject.transform.position = position;
        ParticleSystem[] particles = explosionsBatiment[currentBatiment].GetComponentsInChildren<ParticleSystem>();

        foreach (ParticleSystem particle in particles)
        {
            particle.Play();
        }

        currentBatiment++;
        if (currentBatiment > explosionsBatiment.Length - 1)
            currentBatiment = 0;
    }
}
