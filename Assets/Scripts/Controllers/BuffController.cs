using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class BuffController : MonoBehaviour
{
    public static BuffController _instance;
    public Color buffTextColor;
    public int buffTextSize;

    [Header("buff delay sound")]
    public float value;

    //Go through each card in your DECK and apply the buff
    public void BuffDamage(){
        print("BuffDamage applied");
        //play sound clip
        StartCoroutine(Delay(value, FMODUnity.AudioManager._instance.AttackSoundeffect));
        foreach(Transform _card in CardSystemManager._instance.CardDeckPos.transform){
            if(_card.GetComponent<CardTemplate>().card.AttackDamage > 0){
                _card.GetComponent<CardTemplate>().DamageText.color = buffTextColor;
                _card.GetComponent<CardTemplate>().DamageText.fontSize = buffTextSize;
                _card.GetComponent<CardTemplate>().cardDamageValue *= 2;
                _card.GetComponent<CardTemplate>().UpdateCardValues();
                //print("new value: " + _card.GetComponent<CardTemplate>().cardDamageValue);
            }
        }
    }

    public void BuffHealing(){
        print("BuffHealing applied");
        foreach(Transform _card in CardSystemManager._instance.CardDeckPos.transform){
            if(_card.GetComponent<CardTemplate>().card.Health > 0){
                _card.GetComponent<CardTemplate>().DamageText.color = buffTextColor;
                _card.GetComponent<CardTemplate>().DamageText.text = "<color=black>Gain</color> " + _card.GetComponent<CardTemplate>().cardHealValue + " Health";
                _card.GetComponent<CardTemplate>().DamageText.fontSize = buffTextSize;
                _card.GetComponent<CardTemplate>().cardHealValue *= 2;
                _card.GetComponent<CardTemplate>().UpdateCardValues();
            }
        }
    }

    public void BuffShielding(){
        print("BuffShielding applied");
        foreach(Transform _card in CardSystemManager._instance.CardDeckPos.transform){
            if(_card.GetComponent<CardTemplate>().card.Shield > 0){
                _card.GetComponent<CardTemplate>().DamageText.color = buffTextColor;
                _card.GetComponent<CardTemplate>().DamageText.text = "<color=black>Gain</color> " + _card.GetComponent<CardTemplate>().cardShieldValue + " Shield";
                _card.GetComponent<CardTemplate>().DamageText.fontSize = buffTextSize;
                _card.GetComponent<CardTemplate>().cardShieldValue *= 2;
                _card.GetComponent<CardTemplate>().UpdateCardValues();
            }
        }
    }

    public IEnumerator Delay(float time, FMODUnity.EventReference soundEffect){
        FMODUnity.AudioManager._instance.TriggerSoundEffect(soundEffect);
        print("Trigger sound");
        yield return new WaitForSeconds(time);
        AnimationController._instance.PlayParticleList(AnimationController._instance.PowerUpAttackBelle);
    }

    private void Awake() {
        if(_instance != null){
            Destroy(gameObject);
        }else{
            _instance = this;
        }
    }
}

    

    
