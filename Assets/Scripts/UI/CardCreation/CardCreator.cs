using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardCreator : MonoBehaviour
{
    public static CardCreator _instance;
    public List<Card> PlayerCardProfiles;
    public GameObject CardSpawnPoint; 
    public GameObject CardPrefab;

    public void SpawnCardList(){
        foreach( Card profile in PlayerCardProfiles){
            GameObject myCard;
            myCard = Instantiate(CardPrefab, CardSpawnPoint.transform);
            myCard.GetComponent<CardTemplate>().card = profile;
        }
    }

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
        }
    }
}
