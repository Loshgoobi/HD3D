using UnityEngine;
using System.Collections;


    public class EnemyAttack : MonoBehaviour
    {
        
        public int attackDamage = 10;               // The amount of health taken away per attack.


        private Animator anim;                              // Reference to the animator component.
        GameObject homeBase;                          // Reference to the player GameObject.
        public BaseHealth baseHealth;                  // Reference to the player's health. 
        private EnemyHealth enemyHealth;                    // Reference to this enemy's health.
        private bool playerInRange;                         // Whether player is within the trigger collider and can be attacked.
        private float timer;                                // Timer for counting up to the next attack.


        void Start ()
        {
        // Setting up the references.
            homeBase = GameObject.FindGameObjectWithTag ("Base");
            baseHealth = homeBase.GetComponent <BaseHealth> ();
            enemyHealth = GetComponent<EnemyHealth>();
        // anim = GetComponent <Animator> ();
        Debug.Log("first debug : " + homeBase);
        Debug.Log("base health : " + baseHealth.currentHealth);
    }


        void OnTriggerEnter (Collider other)
        {
            // If the entering collider is the base...
            if(other.tag == "Base")
            {
            Debug.Log("In collider");
                Attack();
            }
        }


        void OnTriggerExit (Collider other)
        {
            // If the exiting collider is the player...
            if(other.tag == "Base")
            {
                // ... the player is no longer in range.
                playerInRange = false;
            }
        }


        void Update ()
        {

        }


        public void Attack ()
        {
        Debug.Log("base health : " + baseHealth.currentHealth);
        // If the player has health to lose...
        if (baseHealth.currentHealth > 0)
            {
            Debug.Log("Attacking!");
            // ... damage the base.
            baseHealth.TakeDamage (attackDamage);
            Destroy(gameObject);
            }
        }
    }
