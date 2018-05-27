using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileShootTriggerable : MonoBehaviour {


    [HideInInspector] public Rigidbody missile;                          // Rigidbody variable to hold a reference to our projectile prefab

    public Transform missileSpawn;                           // Transform variable to hold the location where we will spawn our projectile

    [HideInInspector] public float projectileForce = 250f;

    public void Launch()
    {
        Debug.Log("in Launch");
        //Instantiate a copy of our projectile and store it in a new rigidbody variable called clonedBullet
        //Instantiate(missile, missileSpawn.position, transform.rotation);
        

        //Instantiate a copy of our projectile and store it in a new rigidbody variable called clonedBullet
        Rigidbody clonedBullet = Instantiate(missile, missileSpawn.position, transform.rotation) as Rigidbody;

        //Add force to the instantiated bullet, pushing it forward away from the bulletSpawn location, using projectile force for how hard to push it away
        clonedBullet.AddForce(missileSpawn.transform.forward * projectileForce);

        Debug.Log("Launched");
    }
}
