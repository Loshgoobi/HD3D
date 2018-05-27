using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillAllTriggerable : MonoBehaviour {

    //[HideInInspector] public GameObject[] enemies;
    public void KillAll()
    {
        Debug.Log("In Kill All");

        EnemyHealth[] enemies = FindObjectsOfType<EnemyHealth>();
        Debug.Log("number of enemies : " + enemies.Length);



        for (int i = 0; i <= enemies.Length; i++)
        {
            Debug.Log("number of enemies : " + enemies[i].name);
            enemies[i].TakeDamage(enemies[i].currentHealth);
        }
    }

}
