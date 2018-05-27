﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


using UnityEngine;
using System.Collections;

public class EnemyMove : MonoBehaviour
{
    Transform target;               // Reference to the target's position.
    EnemyHealth enemyHealth;        // Reference to this enemy's health.
    NavMeshAgent nav;               // Reference to the nav mesh agent.


    void Start()
    {
        // Set up the references.
        target = GameObject.FindGameObjectWithTag("Target").transform;


        nav = GetComponent<NavMeshAgent>();
        nav.SetDestination(target.position);
        Debug.Log("Destination : " + nav.destination);
        Debug.Log("Remaining distance : " + nav.remainingDistance);
    }

    // Update is called once per frame


    void Update()
    {
        float dist = Vector3.Distance(target.transform.position, transform.position);
        if (dist <= 1.0f)
        {
            Destroy(gameObject);
        }
    }
}
