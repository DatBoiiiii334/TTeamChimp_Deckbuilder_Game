using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardTemplate : MonoBehaviour
{
    public Card card;
    public delegate void AllSpellsFromCard();
    public AllSpellsFromCard myCardSpells;
    public TextMeshProUGUI nameText, descriptionText, ManaValue, AttackValue, HealValue, TempDescription, DamageText, PassiveText;
    public Card.cardType _card;
    public Image CharCardArt;
    public int cardDamageValue, cardTickValue, cardHealValue, cardShieldValue;

    private void Start()
    {
        SyncCardValues();
        ScriptAdder();
    }

    public void SyncCardValues(){
        cardDamageValue = card.AttackDamage;
        cardHealValue = card.Health;
        cardShieldValue = card.Shield;
        cardTickValue = card.TickDamage;
        nameText.text = card.Name;
        CharCardArt.sprite = card.Image;
        TempDescription.text = card.Description;
        descriptionText.text = card.Description;
        DamageText.text = "<color=black>Deal</color> " + cardDamageValue + " damage";
        DamageText.color = Color.red;
        PassiveText.text = "<color=black>Apply</color> " + card.TickDamage + " bleed";
        PassiveText.color = Color.blue;
        ManaValue.text = card.Mana.ToString();
        print("changed value: " + cardDamageValue);
    }

    public void UpdateCardValues(){
        TempDescription.text = card.Description;
        descriptionText.text = card.Description;
        DamageText.text = "<color=black>Deal</color> " + cardDamageValue + " damage";
        PassiveText.text = "<color=black>Apply</color> " + card.TickDamage + " bleed";
        ManaValue.text = card.Mana.ToString();
    }

    public void ScriptAdder()
    {
        foreach (BaseEffect ability in card.Effects)
        {
            if (card.Effects.Count == 0) { return; }
            ability.template = gameObject.GetComponent<CardTemplate>();
            myCardSpells += ability.ApplyEffect;
        }
    }

    public void ExecuteAction()
    {
        if (myCardSpells != null)
        {
            myCardSpells();
            Player._player.Mana -= card.Mana;
            Player._player.UpdatePlayerUI();
            EnemyBody._instanceEnemyBody.UpdateEnemyUI();
            SyncCardValues();
        }
    }
}
