using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : Humanoid
{
    public static Player _player;
    public int Mana, forPlayerTicks, tickforPlayerDmg;
    public TextMeshProUGUI ManaField, _forPlayerTicks;
    public GameObject BleedIcon;
    public Slider hpSlider;
    public Animator anim;

    private void Awake()
    {
        if (_player != null)
        {
            Destroy(gameObject);
        }
        _player = this;
        anim = gameObject.GetComponent<Animator>();
    }

    public void Start()
    {
        anim.Play("DEV_Idle");
        hpSlider.maxValue = maxHealth;
        NameField.text = Name;
        UpdatePlayerUI();
    }

    public void UpdatePlayerUI()
    {
        //NameField.text = Name;
        if(forPlayerTicks > 0){
            BleedIcon.SetActive(true);
            _forPlayerTicks.text = forPlayerTicks.ToString();
        }
        if(forPlayerTicks <= 0){
            BleedIcon.SetActive(false);
        }
        HealthField.text = Health.ToString() + "/" + maxHealth;
        ShieldField.text = Shield.ToString();
        //ManaField.text = Mana.ToString();
        hpSlider.value = Health;
    }

    public void ResetPlayerStats(){
        Health = maxHealth;
        Shield = maxShield;
        //PlayerTurnState.PlayerTurnAmount();
        GameManager._instance.GiveHand();
        UpdatePlayerUI();
    }
}
