using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TirsMilitaires : MonoBehaviour
{
    public GameObject projectile;
    public Military attachedBuilding;
    WaitForSeconds wfst;
    CollisionAliens target;
    public GameObject shoot;

    public Transform alienOverlapCenter;
    public LayerMask alienOverlapLayeMask;

    public void initBuilding()
    {
        StartCoroutine(tir());
        wfst = new WaitForSeconds(attachedBuilding.ShootingRate);
    }

    IEnumerator tir()
    {
        while (true)
        {
            FindTarget();
            if (target != null)
            {
                Vector3 direction = (target.transform.position - shoot.transform.position).normalized;
                Quaternion rotation = Quaternion.FromToRotation(Vector3.forward, direction);
                GameObject bullet = Instantiate(projectile, shoot.transform.position, rotation);

                ParticleSystem[] tirs = shoot.GetComponentsInChildren<ParticleSystem>();

                foreach (ParticleSystem particle in tirs)
                {
                    particle.Play();
                }

                ProjectileMilitaire projectileMilitaire = bullet.GetComponent<ProjectileMilitaire>();
                if (projectileMilitaire != null)
                    projectileMilitaire.initProjectile(attachedBuilding.Damages);
                bullet.GetComponent<Rigidbody>().AddForce(direction * (1000f));

                // détruit le projectile après 4 secondes
                Destroy(bullet, 10f);
            }
            yield return wfst;
        }
    }

    private void FindTarget()
    {
        target = null;
        Collider[] colliders = Physics.OverlapSphere(alienOverlapCenter.position, 3.5f, alienOverlapLayeMask);
        
        if (colliders.Length > 0) {
            target = colliders[0].GetComponent<CollisionAliens>();
            LookAtTarget();
        }
    }

    public Transform verticalRotation;

    private void LookAtTarget()
    {
        if(target!=null)
            verticalRotation.LookAt(target.transform);
    }

    /*private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(alienOverlapCenter.position, 3.5f);
    }*/

    /*private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("alien"))
        {
            CollisionAliens newTarget = other.GetComponent<CollisionAliens>();
            target = newTarget;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("alien") || target == null)
            return;
        if (other.gameObject.Equals(target.gameObject))
            target = null;
    }*/
}
