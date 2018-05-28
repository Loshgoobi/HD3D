using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

    public GameObject enemyMutan;
    public GameObject enemyVampire;

    public float spawnTime;
    public Transform[] spawnPoints;
    public bool flag;

    public int waveNumberWin;

    private int currentWaveNumber;

	void Start () {
        InvokeRepeating("Spawn", spawnTime, spawnTime);
        flag = false;
        currentWaveNumber = 0;
	}

    private void Update()
    {
        if(currentWaveNumber == waveNumberWin)
        {
            gameObject.SetActive(false);  
        }
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
        currentWaveNumber++;
    }
    
}
