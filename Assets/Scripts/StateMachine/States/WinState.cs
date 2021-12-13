using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class WinState : State
{
    public static WinState  _instance;
    public GameObject CardPrefab, CardSpawnPoint, CardDisplay;
    public List<Card> AllNewCardProfiles;

    public override void Enter()
    {
        StartCoroutine(OnEnter());
    }

    public override void Exit()
    {
        StartCoroutine(OnExit());
    }

    public void OpenNewCardsWindow()
    {
        CardDisplay.SetActive(true);
        PlaceNewCards();
    }

    public void CloseNewCardsWindow()
    {
        CardDisplay.SetActive(false);
    }

    public void PlaceNewCards()
    {
        if(CardSpawnPoint.transform.childCount > 0){
            foreach(Transform _card in CardSpawnPoint.transform){
                Destroy(_card.transform.gameObject);
            }
        }
        for (int i = 0; i < 3; i++)
        {
            GameObject myCard;
            myCard = Instantiate(CardPrefab, CardSpawnPoint.transform);
            myCard.GetComponent<DisplayCard>().card = AllNewCardProfiles[Random.Range(0, AllNewCardProfiles.Count)];
            Debug.Log("Name: "+myCard.GetComponent<DisplayCard>().card.name);
        }
    }

    public void GoToMap(){
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
        CloseNewCardsWindow();
    }

    private void Awake() {
        if (_instance != null)
        {
            Destroy(gameObject);
        }
        _instance = this;
    }
}
