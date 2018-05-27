using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour {


    
    Transform target;
    NavMeshAgent agent;
    GameObject playerBase;
    BaseHealth baseManager;

    //serialiser la target


	// Use this for initialization
	void Start () {
        target = GameObject.FindGameObjectWithTag("Target").transform;
        playerBase = GameObject.FindGameObjectWithTag("Base");
        baseManager = playerBase.GetComponent<BaseHealth>();
        
        agent = GetComponent<NavMeshAgent>();
        agent.destination = target.position;
		
	}
	
	// Update is called once per frame
	void Update () {
        if (agent.remainingDistance <= 1.0f) 
        {
            baseManager.TakeOneDamage();
            Destroy(agent.gameObject);    
        }	
	}

    /*

    Transform target;
    Transform playerBase;
    NavMeshAgent nav;
    EnemyHealth enemyHealth;
    
    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Target").transform;
        playerBase = GameObject.FindGameObjectWithTag("Base").transform;
        enemyHealth = GetComponent<EnemyHealth>();


        nav = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        nav.SetDestination(target.position);
        if (nav.remainingDistance == 0)
        {
            Destroy(nav.gameObject);
        }
    }

    public void Attack()
    {
        if (nav.remainingDistance == 0)
        {
            Destroy(nav.gameObject);
        }
    }
    */
}
