using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class HomingMissile : MonoBehaviour
{

    
    
    public float speed = 5f;
    public float rotateSpeed = 200f;

    private Rigidbody rb;
    private Transform missile;
    private Transform target;


    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        missile = GetComponent<Transform>();
        target = FindClosestToTarget(missile, "Enemy").transform;
        Debug.Log("Enemy : " + target.name);
    }

    void FixedUpdate()
    {
        Vector3 direction = target.position - rb.position;
        direction.Normalize();
        Vector3 rotateAmount = Vector3.Cross(transform.forward, direction);
        rb.angularVelocity = rotateAmount * rotateSpeed;
        rb.velocity = transform.forward * speed;
    }

    void OnTriggerEnter()
    {
        // Put a particle effect here
        Destroy(gameObject);
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
}
