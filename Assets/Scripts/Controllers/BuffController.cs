using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BuffController : MonoBehaviour
{
    public static BuffController _instance;
    public Color buffTextColor;
    public int buffTextSize;

    //Go through each card in your DECK and apply the buff
    public void BuffDamage(){
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

    private void Awake() {
        if(_instance != null){
            Destroy(gameObject);
        }else{
            _instance = this;
        }
    }
}

    

    
