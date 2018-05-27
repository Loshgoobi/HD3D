using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/KillAll")]
public class KillAll : Ability
{

    public GameObject[] enemies;
    

    public override void Initialize(GameObject obj)
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemies");
        Debug.Log("number of enemies : " + enemies.Length);
    }

    public override void TriggerAbility()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemies");
        Debug.Log("number of enemies : " + enemies.Length);
        for (int i = 0; i <= enemies.Length; i++)
        {
            Destroy(enemies[i]);
        }
    }
}
