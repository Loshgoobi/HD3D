using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


    public class PlayerMana : MonoBehaviour {

        public float startingMana = 100f;                            // The amount of health the player starts the game with.
        public float currentMana;                                   // The current health the player has.
        public Slider manaSlider;                                 // Reference to the UI's mana bar.

    void Awake()
    {
        // Set the initial mana of the player.
        currentMana = startingMana;
    }
    // Update is called once per frame
    void Update () {
            if(currentMana < 100 )
            {
                currentMana = currentMana + 0.1f;
                manaSlider.value = currentMana;
            }
		
	    }

    public void SpendMana(int amount)
    {
        if (amount <= currentMana)
        {
            currentMana -= amount;
            manaSlider.value = currentMana;
        }
        else return;
        
    }

    }


