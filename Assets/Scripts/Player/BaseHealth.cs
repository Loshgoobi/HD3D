﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;


    public class BaseHealth : MonoBehaviour
    {
        public int startingHealth = 100;                            // The amount of health the player starts the game with.
        public int currentHealth;                                   // The current health the player has.
        public Slider healthSlider;                                 // Reference to the UI's health bar.
        public Image damageImage;                                   // Reference to an image to flash on the screen on being hurt.
        public AudioClip deathClip;                                 // The audio clip to play when the player dies.
        public float flashSpeed = 5f;                               // The speed the damageImage will fade at.
        public Color flashColour = new Color(1f, 0f, 0f, 0.1f);     // The colour the damageImage is set to, to flash.
        public int firstStage;
        public int secondStage;
        public GameObject fullhealth;
        public GameObject firstStageObj;
        public GameObject secondStageObj;
        public GameObject destroyed;

    //Animator anim;                                              // Reference to the Animator component.
        AudioSource playerAudio;                                    // Reference to the AudioSource component.
        ParticleSystem hitParticles;
        ParticleSystem destructionParticles;
        //PlayerMovement playerMovement;                              // Reference to the player's movement.
        PlayerShooting playerShooting;                                // Reference to the PlayerShooting script.
         BoxCollider boxCollider;
        bool isDead;                                                // Whether the player is dead.
        bool damaged;                                               // True when the player gets damaged.

        private int stage;

        void Awake ()
        {
        // Setting up the references.
        //anim = GetComponent <Animator> ();
        //playerAudio = GetComponent <AudioSource> ();
        // playerMovement = GetComponent <PlayerMovement> ();
            destructionParticles = GetComponent <ParticleSystem> ();
            playerShooting = GetComponentInChildren <PlayerShooting> ();
            boxCollider = GetComponent <BoxCollider> ();
            // Set the initial health of the player.
            currentHealth = startingHealth;
            healthSlider.value = currentHealth;
            stage = 0;
        }


        void Update ()
        {
            // If the player has just been damaged...
            if(damaged)
            {
                // ... set the colour of the damageImage to the flash colour.
                damageImage.color = flashColour;
            }
            // Otherwise...
            else
            {
                // ... transition the colour back to clear.
                damageImage.color = Color.Lerp (damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
            }

            // Reset the damaged flag.
            damaged = false;
        }

    void OnTriggerEnter(Collider other)
    {
        // If the entering collider is the base...
        if (other.tag == "Enemy")
        {
            
            //Debug.Log("In collider");
            TakeDamage(15);
            Destroy(other.gameObject);
        }
        if (other.tag == "BigEnemy")
        {

            //Debug.Log("In collider");
            TakeDamage(50);
            Destroy(other.gameObject);
        }
    }


    public void TakeDamage (int amount)
        {
            // Set the damaged flag so the screen will flash.
            damaged = true;
            //Debug.Log("Damage amount : " + amount);
            // Reduce the current health by the damage amount.
            currentHealth -= amount;

            // Set the health bar's value to the current health.
            healthSlider.value = currentHealth;

            // Play the hurt sound effect.
            //playerAudio.Play ();

            if( currentHealth <= firstStage && currentHealth > secondStage && stage == 0 )
            {
                //destructionParticles.Play();
                Destroy(fullhealth);
                firstStageObj.SetActive(true);
                stage = 1;
            }
            else if (currentHealth <= secondStage && !isDead && stage == 1)
            {
                //destructionParticles.Play();
                Destroy(firstStageObj);
                secondStageObj.SetActive(true);
            }

            // If the player has lost all it's health and the death flag hasn't been set yet...
            if(currentHealth <= 0 && !isDead)
            {
                //destructionParticles.Play();
                Destroy(secondStageObj);
                destroyed.SetActive(true);
                // ... it should die.
                Death ();
            }
        }

    public void TakeOneDamage()
    {
        // Set the damaged flag so the screen will flash.
        damaged = true;

        if (isDead)
        {
            return;
        }

        currentHealth -= 1;
        // Set the health bar's value to the current health.
        healthSlider.value = currentHealth;

        if (currentHealth <= 0)
        {
            Death();
        }
    }


    void Death ()
        {
            // Set the death flag so this function won't be called again.
            isDead = true;

            // Turn off any remaining shooting effects.
            playerShooting.DisableEffects ();

            // Tell the animator that the player is dead.
            //anim.SetTrigger ("Die");

            // Set the audiosource to play the death clip and play it (this will stop the hurt sound from playing).
            //playerAudio.clip = deathClip;
            //playerAudio.Play ();

            // Turn off the movement and shooting scripts.
            //playerMovement.enabled = false;
            playerShooting.enabled = false;
        }


        public void RestartLevel ()
        {
            // Reload the level that is currently loaded.
            SceneManager.LoadScene (0);
        }

        public void TakeDamage(int amount, Vector3 hitPoint)
        {
            if (isDead)
                return;

            currentHealth -= amount;

            hitParticles.transform.position = hitPoint;
            hitParticles.Play();

            if (currentHealth <= 0)
            {
                Death();
            }
        }
}
