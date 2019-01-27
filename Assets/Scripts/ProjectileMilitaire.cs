using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMilitaire : MonoBehaviour
{
    int damage;

    public void initProjectile(int turretDamage)
    {
        damage = turretDamage;
    }

    private void OnTriggerEnter(Collider other)
    {
        AlienManager target = other.gameObject.GetComponent<AlienManager>();
        if (target == null)
            return;
        target.Health -= damage;
        if (target.Health <= 0)
        {
            // TODO son d'explosion
            Explosions.instance.spawnParticleAlien(transform.position);
            Destroy(other.transform.parent.gameObject);
            Character.increaseScore();
        }
        Destroy(this.gameObject);
    }
}
