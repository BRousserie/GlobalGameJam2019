using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileAlien : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        Building target = other.gameObject.GetComponent<Building>();
        if (target == null)
            return;
        target.Health -= 5;
        print(target.Health);
        if (target.Health <= 0)
        {
            //explosion
            Explosions.instance.spawnParticleBatiment(transform.position);
            Destroy(other.gameObject);
        }
        Destroy(this.gameObject);
    }
}
