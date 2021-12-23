using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardPicker : MonoBehaviour
{
    public static CardPicker instance_CardPicker;
    public GameObject CardPrefab, CardSpawnPoint, CardDisplay;
    public List<Card> AllNewCardProfiles;

    public void OpenNewCardsWindow()
    {
        print("YELL");
        CardDisplay.SetActive(true);
        PlaceNewCards();
    }

    public void CloseNewCardsWindow()
    {
        CardDisplay.SetActive(false);
        //GameManager._instance.RemoveCards(CardSpawnPoint.transform);
    }

    public void PlaceNewCards()
    {
        for (int i = 0; i < 3; i++)
        {
            int randomvalue;
            GameObject myCard;
            randomvalue = Random.Range(0, AllNewCardProfiles.Count);
            myCard = Instantiate(CardPrefab, CardSpawnPoint.transform);
            myCard.GetComponent<DisplayCard>().card = AllNewCardProfiles[randomvalue];
        }
    }

    private void Awake()
    {
        if (instance_CardPicker != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance_CardPicker = this;
        }
    }
}
