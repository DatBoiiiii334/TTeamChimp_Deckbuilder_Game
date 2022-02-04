using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class WinState : State
{
    public static WinState  _instance;
    public GameObject CardPrefab, CardSpawnPoint, CardDisplay;


    [Header("Win cards")]
    public GameObject winCard1, winCard2, winCard3;

    public override void Enter()
    {
        StartCoroutine(OnEnter());
    }

    public override void Exit()
    {
        // StartCoroutine(OnExit());
    }

    public void OpenNewCardsWindow()
    {
        CardDisplay.SetActive(true);
        PlaceNewCards();
    }

    public void PlaceNewCards()
    {
        winCard1.GetComponent<DisplayCard>().card = CardPicker.instance_CardPicker.AllNewCardProfiles[Random.Range(0, CardPicker.instance_CardPicker.AllNewCardProfiles.Count)];
        winCard2.GetComponent<DisplayCard>().card = CardPicker.instance_CardPicker.AllNewCardProfiles[Random.Range(0, CardPicker.instance_CardPicker.AllNewCardProfiles.Count)];
        winCard3.GetComponent<DisplayCard>().card = CardPicker.instance_CardPicker.AllNewCardProfiles[Random.Range(0, CardPicker.instance_CardPicker.AllNewCardProfiles.Count)];
        // if(CardSpawnPoint.transform.childCount > 0){
        //     foreach(Transform _card in CardSpawnPoint.transform){
        //         Destroy(_card.transform.gameObject);
        //     }
        // }
        // for (int i = 0; i < 3; i++)
        // {
        //     GameObject myCard;
        //     myCard = Instantiate(CardPrefab, CardSpawnPoint.transform);
        //     myCard.GetComponent<DisplayCard>().card = CardPicker.instance_CardPicker.AllNewCardProfiles[Random.Range(0, CardPicker.instance_CardPicker.AllNewCardProfiles.Count)];
        //     Debug.Log("Name: "+myCard.GetComponent<DisplayCard>().card.name);
        // }
    }

    public void GoToMap(){
        StartCoroutine(OnExit());
        myFSM.SetCurrentState(typeof(GridMapState));
        print("GO to map pls");
    }

    private IEnumerator OnEnter(){
        GameManager._instance.TransitionScreenAnim.SetTrigger("StartTransition");
        yield return new WaitForSeconds(2f);
        OpenNewCardsWindow();
    }

    private IEnumerator OnExit(){
        GameManager._instance.TransitionScreenAnim.SetTrigger("StartTransition");
        yield return new WaitForSeconds(2f);
        CardDisplay.SetActive(false);
        GameManager._instance.FightScene.SetActive(false);
    }

    private void Awake() {
        if (_instance != null)
        {
            Destroy(gameObject);
        }
        _instance = this;
    }
}
