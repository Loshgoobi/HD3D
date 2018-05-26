using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{

    GameObject enemy;
    float spawnTime = 3f;
    Transform spawnPoints;
    int enemyNumber;


    // Use this for initialization
    void Start()
    {
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    void Spawn()
    {
        if(enemy != null)
        {
            Instantiate(enemy, spawnPoints.position, spawnPoints.rotation);
        }
        
        
    }
}
