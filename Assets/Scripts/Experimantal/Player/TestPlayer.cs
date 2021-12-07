using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TestPlayer : Humanoid
{
    public static TestPlayer _testPlayer;
    public int Mana;
    public TextMeshProUGUI ManaField;
    public Slider hpSlider, shieldSlider;
    public Animator anim;

    private void Awake()
    {
        if (_testPlayer != null)
        {
            Destroy(gameObject);
        }
        _testPlayer = this;
        anim = gameObject.GetComponent<Animator>();
    }

    public void Start()
    {
        anim.Play("DEV_Idle");
        hpSlider.maxValue = maxHealth;
        shieldSlider.maxValue = maxShield;
        UpdatePlayerUI();
    }

    public void UpdatePlayerUI()
    {
        NameField.text = Name;
        HealthField.text = Health.ToString();
        ShieldField.text = Shield.ToString();
        ManaField.text = Mana.ToString();
        hpSlider.value = Health;
        shieldSlider.value = Shield;
    }
}
