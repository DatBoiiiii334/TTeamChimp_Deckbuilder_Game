using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplayCard : MonoBehaviour
{
    public Card card;

    public TextMeshProUGUI nameText, descriptionText, ManaValue, AttackValue, HealValue;
    //public card.cardType myCardType;
    //public Card.cardType _card;
    public Image CharCardArt;
    //private CardController _instance_Card;

    private void Start()
    {
        nameText.text = card.Name;
        CharCardArt.sprite = card.Image;
        descriptionText.text = card.Description;
        ManaValue.text = card.Mana.ToString();
        AttackValue.text = card.AttackDamage.ToString();
        HealValue.text = card.Health.ToString();
    }

    public void SelectProfile()
    {
        print(card.Name + " Was selected");
        // CardController.instance_CardController.AllCardProfiles.Add(card);
       // CardController._instance_CC.PlayerCards.Add(card, 1);
        CardPicker.instance_CardPicker.AllNewCardProfiles.Remove(card);
        CardPicker.instance_CardPicker.CloseNewCardsWindow();
        Destroy(gameObject);
    }
}
