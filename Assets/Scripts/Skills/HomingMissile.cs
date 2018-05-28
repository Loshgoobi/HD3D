using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class HomingMissile : MonoBehaviour
{

    public float speed = 5f;
    public float rotateSpeed = 200f;
    public float radius = 5.0f;
    public float force = 700.0f;
    public int damage = 50;

    public GameObject explosionEffect;

    private Rigidbody rb;
    private Transform missile;
    private Transform target;
    private GameObject instantiatedEffect;
    private ParticleSystem ps;
    private AudioSource abilitySource;


    // Use this for initialization
    void Start()
    {
        abilitySource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
        missile = GetComponent<Transform>();
        target = FindClosestToTarget(missile, "Enemy").transform;
        //Debug.Log("Enemy : " + target.name);
        if(!target)
        {
            target = FindClosestToTarget(missile, "BigEnemy").transform;
        }
    }

    void FixedUpdate()
    {
        Vector3 direction = target.position - rb.position;
        direction.Normalize();
        Vector3 rotateAmount = Vector3.Cross(transform.forward, direction);
        rb.angularVelocity = rotateAmount * rotateSpeed;
        rb.velocity = transform.forward * speed;
        //Debug.Log("target name : " + target.name);
        target = FindClosestToTarget(missile, "Enemy").transform;
        //Debug.Log("Enemy : " + target.name);
        if (!target)
        {
            target = FindClosestToTarget(missile, "BigEnemy").transform;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "BigEnemy")
        {
            //Debug.Log("Enemy collision is present!");
            Explode();
            Destroy(gameObject);
        }
        
    }

    GameObject FindClosestToTarget(Transform target, string tag)
    {
        GameObject[] options = GameObject.FindGameObjectsWithTag(tag);

        if (options.Length == 0)
            return null;

        GameObject closest = options[0];
        float closestDistance = Vector3.Distance(target.position, closest.transform.position);
        float thisDistance;

        for (int i = 1; i < options.Length; i++)
        {
            thisDistance = Vector3.Distance(target.position, options[i].transform.position);
            if (thisDistance < closestDistance)
            {
                closest = options[i];
                closestDistance = thisDistance;
            }
        }
        return closest;
    }

    void Explode()
    {
        instantiatedEffect = Instantiate(explosionEffect, transform.position, transform.rotation);
        ps = instantiatedEffect.GetComponent<ParticleSystem>();


        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        int lengthCollider = colliders.Length;
        Debug.Log(lengthCollider);


        foreach (Collider nearbyObject in colliders)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            EnemyHealth eh = nearbyObject.GetComponent<EnemyHealth>();
            if (rb != null && eh != null)
            {
                rb.AddExplosionForce(force, transform.position, radius);
                eh.TakeDamage(damage / 2);
            }


        }
        Destroy(instantiatedEffect, ps.duration);

    }
}
