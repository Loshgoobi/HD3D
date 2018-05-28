using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AbilityCoolDown : MonoBehaviour
{
    public KeyCode keyCode;
    //public string abilityButtonAxisName;
    public Image darkMask;
    public Text coolDownTextDisplay;
    public PlayerMana manaP;

    [SerializeField] private Ability ability;
    [SerializeField] private GameObject weaponHolder;
    
    private Image myButtonImage;
    private AudioSource abilitySource;
    private float coolDownDuration;
    private float nextReadyTime;
    private float coolDownTimeLeft;


    void Start()
    {
        Initialize(ability, weaponHolder);
        
    }

    public void Initialize(Ability selectedAbility, GameObject weaponHolder)
    {
        ability = selectedAbility;
        myButtonImage = GetComponent<Image>();
        abilitySource = GetComponent<AudioSource>();
        myButtonImage.sprite = ability.aSprite;
        darkMask.sprite = ability.aSprite;
        coolDownDuration = ability.aBaseCoolDown;
        ability.Initialize(weaponHolder);
        AbilityReady();
    }

    // Update is called once per frame
    void Update()
    {
        bool coolDownComplete = (Time.time > nextReadyTime);
        if (coolDownComplete)
        {
            AbilityReady();
            if (Input.GetKeyDown(keyCode))
            {
                ButtonTriggered();
            }
        }
        else
        {
            CoolDown();
        }
    }

    private void AbilityReady()
    {
        coolDownTextDisplay.enabled = false;
        darkMask.enabled = false;
    }

    private void CoolDown()
    {
        coolDownTimeLeft -= Time.deltaTime;
        float roundedCd = Mathf.Round(coolDownTimeLeft);
        coolDownTextDisplay.text = roundedCd.ToString();
        darkMask.fillAmount = (coolDownTimeLeft / coolDownDuration);
    }

    private void ButtonTriggered()
    {
        Debug.Log("button triggered");
        //Debug.Log("mana cost" + ability.manaCost);
        nextReadyTime = coolDownDuration + Time.time;
        coolDownTimeLeft = coolDownDuration;
        darkMask.enabled = true;
        coolDownTextDisplay.enabled = true;

        //abilitySource.clip = ability.aSound;
        //abilitySource.Play();
        //Debug.Log("mana cost" + ability.manaCost);
        manaP.SpendMana(ability.manaCost);
        //Debug.Log("mana spent");
        ability.TriggerAbility();
        Debug.Log("Triggered");
    }
}