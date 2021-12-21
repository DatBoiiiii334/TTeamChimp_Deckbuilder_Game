using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardTemplate : MonoBehaviour
{
    public Card card;

    public delegate void AllSpellsFromCard();
    public AllSpellsFromCard myCardSpells;
    public TextMeshProUGUI nameText, descriptionText, ManaValue, AttackValue, HealValue, TempDescription;

    public Card.cardType cardType;
    public CardTopolis._cardType things;

    public Image CharCardArt, CardTypeIcon;
    public Sprite DamageIcon, BuffIcon, DebuffIcon, HealingIcon;

    private void Start()
    {
        ShowCardType();
        ScriptAdder();
        //things = CardTopolis._cardType;
        nameText.text = card.Name;
        CharCardArt.sprite = card.Image;
        TempDescription.text = card.Description;
        descriptionText.text = card.Description;
        ManaValue.text = card.Mana.ToString();
    }

    public void ShowCardType(){
        switch(((int)cardType)){
            case 0:
            CardTypeIcon.sprite = DamageIcon;
            break;
            
            case 1:
            CardTypeIcon.sprite = BuffIcon;
            break;

            case 2:
            CardTypeIcon.sprite = DebuffIcon;
            break;

            case 3:
            CardTypeIcon.sprite = HealingIcon;
            break;

            default:
            Debug.LogError("No card Icon selected on: "+ card.name + " in "+ gameObject.name);
            break;
        }
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
        }
    }
}
