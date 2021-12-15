using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplayCard : MonoBehaviour
{
    public Card card;

    public TextMeshProUGUI nameText, descriptionText, descriptionTextSecond, ManaValue;
    public Image CharCardArt;

    private void Start()
    {
        nameText.text = card.Name;
        CharCardArt.sprite = card.Image;
        descriptionText.text = card.Description;
        descriptionTextSecond.text = card.Description;
        ManaValue.text = card.Mana.ToString();
    }

    public void SelectProfile()
    {
        print(card.Name + " Was selected");
        WinState._instance.AllNewCardProfiles.Remove(card);
        CardCreator._instance.PlayerCardProfiles.Add(card);
        Destroy(gameObject.transform.gameObject);
        WinState._instance.GoToMap();
    }
}
