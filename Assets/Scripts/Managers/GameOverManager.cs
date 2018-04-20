using UnityEngine;


public class GameOverManager : MonoBehaviour
{
    public BaseHealth baseHealth;


    Animator anim;


    void Awake()
    {
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        if (baseHealth.currentHealth <= 0)
        {
           anim.SetTrigger("GameOver");
        }
    }
}


