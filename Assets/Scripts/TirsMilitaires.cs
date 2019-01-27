using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TirsMilitaires : MonoBehaviour
{
    public GameObject projectile;
    WaitForSeconds wfst = new WaitForSeconds(5f);
    AlienManager target;

    public void initBuilding()
    {
        StartCoroutine(tir());
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
                bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.up * (500f));
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("alien"))
        {
            AlienManager newTarget = other.GetComponent<AlienManager>();
            target = newTarget;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("alien"))
            return;
        if (other.GetComponent<AlienManager>().Equals(target))
            target = null;
    }
}
