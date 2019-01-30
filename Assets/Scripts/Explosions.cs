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
    public GameObject[] explosionsBatimentHit;
    int currentAlien = 0;
    int currentBatiment = 0;
    int currentBatimentHit = 0;

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

    public void spawnParticleBatimentJustHit(Vector3 position)
    {
        explosionsBatimentHit[currentBatimentHit].gameObject.transform.position = position;
        ParticleSystem[] particles = explosionsBatimentHit[currentBatimentHit].GetComponentsInChildren<ParticleSystem>();

        foreach (ParticleSystem particle in particles)
        {
            particle.Play();
        }

        currentBatimentHit++;
        if (currentBatimentHit > explosionsBatimentHit.Length - 1)
            currentBatimentHit = 0;
    }
}
