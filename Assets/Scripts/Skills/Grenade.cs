using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour {

    public float delay = 3.0f;
    public float radius = 5.0f;
    public float force = 700.0f;
    public int damage = 50;

    public GameObject explosionEffect;

    private GameObject instantiatedEffect;
    private ParticleSystem ps;

    float countdown;
    bool hasExploded = false;



	// Use this for initialization
	void Start () {
        countdown = delay;
        
    }
	
	// Update is called once per frame
	void Update () {
        countdown -= Time.deltaTime;
        if (countdown <= 0f && !hasExploded)
        {
            hasExploded = true;
            Debug.Log(hasExploded);
            Explode();
            Debug.Log(hasExploded);
            Destroy(gameObject);
            Destroy(explosionEffect);
        }

    }

    void Explode()
    {
        instantiatedEffect = Instantiate(explosionEffect, transform.position, transform.rotation);
        ps = instantiatedEffect.GetComponent<ParticleSystem>();


        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        int lengthCollider = colliders.Length;
        Debug.Log(lengthCollider);


        foreach(Collider nearbyObject in colliders)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            EnemyHealth eh = nearbyObject.GetComponent<EnemyHealth>();
            if (rb != null && eh != null)
            {
                rb.AddExplosionForce(force, transform.position, radius);
                eh.TakeDamage(damage/2);
            }


        }
        Destroy(instantiatedEffect, ps.duration);
        
    }
}
