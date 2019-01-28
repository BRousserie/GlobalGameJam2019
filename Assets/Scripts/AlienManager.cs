using System.Collections;
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
    Building target;
    public ParticleSystem bzzz;

    public Transform buildingOverlapCenter;
    public LayerMask buildingOverlapLayeMask;


    public void initAlien()
    {
        rotation.y = Random.Range(0f, 360f);
        rotation.z = Random.Range(0f, 360f);
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
            rotation.y = Random.Range(-50f, 50f);
            rotation.z = Random.Range(-50f, 50f);
            wfsg = new WaitForSeconds(Random.Range(2f, 5f));
        }
    }

    IEnumerator deplacement()
    {
        while (true)
        {
            yield return wfsd;
            pivot.Rotate(rotation * Time.deltaTime);
        }
    }

    IEnumerator tir()
    {
        while (true)
        {
            yield return wfst;
            FindTarget();
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

    private void FindTarget()
    {
        target = null;
        Collider[] colliders = Physics.OverlapSphere(buildingOverlapCenter.position, .4f, buildingOverlapLayeMask);

        if (colliders.Length > 0)
        {
            target = colliders[0].GetComponent<Building>();
            // TODO LookAtTarget() -> rotation de l'arme de la soucoupe
            // Mais nécessite d'être sûr que la soucoupe fait face à la caméra
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(buildingOverlapCenter.position, .4f);
    }
}
