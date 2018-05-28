using UnityEngine;
using System.Collections;


    public class EnemyAttack : MonoBehaviour
    {
        
        public int attackDamage = 10;               // The amount of health taken away per attack.


        Animator anim;                              // Reference to the animator component.
        GameObject homeBase;                          // Reference to the player GameObject.
        BaseHealth baseHealth;                  // Reference to the player's health.
        EnemyHealth enemyHealth;                    // Reference to this enemy's health.
        bool playerInRange;                         // Whether player is within the trigger collider and can be attacked.
        float timer;                                // Timer for counting up to the next attack.


        void Awake ()
        {
        // Setting up the references.
            homeBase = GameObject.FindGameObjectWithTag ("Base");
            baseHealth = homeBase.GetComponent <BaseHealth> ();
            enemyHealth = GetComponent<EnemyHealth>();
           // anim = GetComponent <Animator> ();
        }


        void OnTriggerEnter (Collider other)
        {
            // If the entering collider is the base...
            if(other.gameObject == homeBase)
            {
            Debug.Log("In collider");
                // ... the player is in range.
                playerInRange = true;
                Debug.Log("In range");
            }
        }


        void OnTriggerExit (Collider other)
        {
            // If the exiting collider is the player...
            if(other.gameObject == homeBase)
            {
                // ... the player is no longer in range.
                playerInRange = false;
            }
        }


        void Update ()
        {
            // Add the time since Update was last called to the timer.
            timer += Time.deltaTime;

            // If the timer exceeds the time between attacks, the player is in range and this enemy is alive...
            if(playerInRange /*&& enemyHealth.currentHealth > 0*/)
            {
                // ... attack.
                Attack ();
            }

            // If the player has zero or less health...
            if(baseHealth.currentHealth <= 0)
            {
                // ... tell the animator the player is dead.
                //anim.SetTrigger ("PlayerDead");
            }
        }


        public void Attack ()
        {
         
            // If the player has health to lose...
            if(baseHealth.currentHealth > 0)
            {
            // ... damage the base.
            baseHealth.TakeDamage (attackDamage);
            Destroy(gameObject);
            }
        }
    }
