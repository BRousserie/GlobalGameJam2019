using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TirsMilitaires : MonoBehaviour
{
    public GameObject projectile;
    public Military attachedBuilding;
    WaitForSeconds wfst;
    CollisionAliens target;

    public void initBuilding()
    {
        StartCoroutine(tir());
        wfst = new WaitForSeconds(attachedBuilding.ShootingRate);
    }

    IEnumerator tir()
    {
        while (true)
        {
            if (target != null)
            {
                Vector3 direction = (transform.position - target.transform.position).normalized;
                Quaternion rotation = Quaternion.FromToRotation(Vector3.up, direction);
                GameObject bullet = Instantiate(projectile, transform.position, rotation);
                bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.up * (1f));
                bullet.GetComponent<ProjectileMilitaire>().initProjectile(attachedBuilding.Damages);
            }
            yield return wfst;
        }
    }

    private void OnTriggerEnter(Collider other)
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
    }
}
