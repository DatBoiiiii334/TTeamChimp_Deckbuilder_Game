using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardCreator : MonoBehaviour
{
    public static CardCreator _instance;
    public List<Card> PlayerCardProfiles;
    public List<Card> TestList;
    public GameObject CardSpawnPoint; 
    public GameObject CardPrefab;

    public void SpawnCardList(){
        foreach( Card profile in PlayerCardProfiles){
            GameObject myCard;
            myCard = Instantiate(CardPrefab, CardSpawnPoint.transform);
            myCard.GetComponent<CardTemplate>().card = profile;
        }
    }

    // private void Update() {
    //     if(Input.GetKeyDown(KeyCode.P)){
    //         Player._player.Mana = 5;
    //         foreach(Transform _card in CardSystemManager._instance.CardDeckPos.transform){
    //             Destroy(_card.gameObject);
    //         }

    //         foreach(Card profile in TestList){
    //             GameObject myCard;
    //             myCard = Instantiate(CardPrefab, CardSystemManager._instance.CardDeckPos.transform);
    //             myCard.GetComponent<CardTemplate>().card = profile;
    //         }
    //         //print("TEEEEEEEEEEST");
    //     }
    // }

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
