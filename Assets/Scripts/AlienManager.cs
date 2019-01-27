using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienManager : MonoBehaviour
{
    public Transform pivot;
    public Transform collision;
    public int Health = 20;
    WaitForSeconds wfsg = new WaitForSeconds(1f);
    WaitForSeconds wfsd = new WaitForSeconds(0.1f);
    WaitForSeconds wfst = new WaitForSeconds(5f);
    Vector3 rotation = Vector3.zero;
    public GameObject projectile;
    //List<Building> targets;
    Building target;
    public ParticleSystem bzzz;


    public void initAlien()
    {
        rotation.y = Random.Range(-90f, 90f);
        rotation.z = Random.Range(-90f, 90f);
        pivot.Rotate(rotation);
        collision.SetParent(pivot.transform);
        rotation = Vector3.zero;
        StartCoroutine(generationRandom());
        StartCoroutine(deplacement());
        StartCoroutine(tir());
    }

    IEnumerator generationRandom()
    {
        while (true)
        {
            yield return wfsg;
            rotation.y = Random.Range(-1.5f, 1.5f);
            rotation.z = Random.Range(-1.5f, 1.5f);
            wfsg = new WaitForSeconds(Random.Range(2f, 5f));
        }
    }

    IEnumerator deplacement()
    {
        while (true)
        {
            yield return wfsd;
            pivot.Rotate(rotation);
        }
    }

    IEnumerator tir()
    {
        while (true)
        {
            yield return wfst;
            if (target != null)
            {
                Vector3 direction = (transform.position - target.transform.position).normalized;
                Quaternion rotation = Quaternion.FromToRotation(Vector3.up, direction);
                GameObject bullet = Instantiate(projectile, transform.position, rotation);
                bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.up * (-300f));
                ParticleSystem[] tir = bzzz.GetComponentsInChildren<ParticleSystem>();
                foreach (ParticleSystem particle in tir)
                {
                    particle.Play();
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("building"))
        {
            Building newTarget = other.GetComponent<Building>();
            target = newTarget;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("building"))
            return;
        if (other.GetComponent<Building>().Equals(target))
            target = null;
    }
}
