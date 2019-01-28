using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileAlien : MonoBehaviour
{
    // Ajout d'une autodestruction car si le batiment a été détruit juste après avoir
    // lancé le projectile par un autre projectile, la cible n'existe plus et les projectiles bougent toujours.
    void Awake()
    {
        // détruit le projectile après 4 secondes
        Destroy(this.gameObject, 4f);
    } 

    private void OnTriggerEnter(Collider other)
    {
        Building target = other.gameObject.GetComponent<Building>();
        if (target == null)
            return;
        target.Health -= 3;
        if (target.Health <= 0)
        {
            //explosion
            Explosions.instance.spawnParticleBatiment(transform.position);

            Military military = other.GetComponent<Military>();
            if(military!=null)
                Destroy(military.collision.gameObject);

            // Commenté car Plante si other.GetComponent<Military>() est null
            /*GameObject militaryCollisionObject = other.GetComponent<Military>().collision.gameObject;
            if (militaryCollisionObject != null) Destroy(militaryCollisionObject);*/

            Destroy(other.gameObject);
        }
        Destroy(this.gameObject);
    }
}
