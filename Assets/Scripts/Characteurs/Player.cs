using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : Humanoid
{
    public static Player _player;
    public int Mana, forPlayerTicks, tickforPlayerDmg;
    public TextMeshProUGUI ManaField, _forPlayerTicks, MaxHealth;
    public GameObject BleedIcon;
    public Slider hpSlider;
    public Animator anim;

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
        //HealthField.text = Health.ToString() + "/" + maxHealth;
        HealthField.text = Health.ToString();
        MaxHealth.text = maxHealth.ToString();
        ShieldField.text = Shield.ToString();
        ManaField.text = Mana.ToString();
        hpSlider.value = Health;
    }

    public void ResetPlayerStats(){
        Health = maxHealth;
        Shield = maxShield;
        forPlayerTicks = 0;
        PlayerTurnState._instance.PlayerTurnAmount = 0;
        UpdatePlayerUI();
    }

    private void Awake()
    {
        if (_player != null)
        {
            Destroy(gameObject);
        }
        _player = this;
        anim = gameObject.GetComponent<Animator>();
    }
}
