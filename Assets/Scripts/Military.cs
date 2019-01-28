using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Military : Building
{
    public int Damages; // damages inflicted by the building
    public float ShootingRate = 2;
    public Transform collision;

    public void initMilitary()
    {
        collision.SetParent(null);
        collision.gameObject.GetComponent<TirsMilitaires>().initBuilding();
    }
}
