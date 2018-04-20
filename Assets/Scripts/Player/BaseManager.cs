using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseManager : MonoBehaviour {

    public int startingHealth = 5;
    public int currentHealth;

    bool isDead;

	// Use this for initialization
	void Start () {

        currentHealth = startingHealth;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void TakeDamage ()
    {
        if (isDead)
        {
            return;
        }

        currentHealth -= 1;
        if (currentHealth <= 0)
        {
            gameOver();
        }
    }

    void gameOver()
    {
        Destroy(gameObject, 2f);
    }
}
