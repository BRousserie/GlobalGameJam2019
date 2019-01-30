using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMilitaire : MonoBehaviour
{
    int damage;
    public GameObject parent;

    public void initProjectile(int turretDamage)
    {
        damage = turretDamage;
    }

    private void OnTriggerEnter(Collider other)
    {
        CollisionAliens targetCollider = other.gameObject.GetComponent<CollisionAliens>();
        if (targetCollider == null)
            return;

        targetCollider.alienManager.Health -= damage;
        if (targetCollider.alienManager.Health <= 0)
        {
            // TODO son d'explosion
            Explosions.instance.spawnParticleAlien(transform.position);

            Destroy(targetCollider.alienManager.gameObject);
            Destroy(targetCollider.gameObject.transform.parent.gameObject);

            Character.increaseScore();
        }
        Destroy(parent);
    }
}
