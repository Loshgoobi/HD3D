using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

    public GameObject enemyMutan;
    public GameObject enemyVampire;

    public float spawnTime;
    public Transform[] spawnPoints;
    public bool flag;

	void Start () {
        InvokeRepeating("Spawn", spawnTime, spawnTime);
        flag = false;
	}
	
    
	void Spawn () {
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        if (flag == true)
        {
            Instantiate(enemyMutan, spawnPoints[spawnPointIndex].position , spawnPoints[spawnPointIndex].rotation);
            flag = false;
            return;
            
        }
        if (flag == false)
        {
            Instantiate(enemyVampire, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
            flag = true;
            return;
        }

    }
    
}
