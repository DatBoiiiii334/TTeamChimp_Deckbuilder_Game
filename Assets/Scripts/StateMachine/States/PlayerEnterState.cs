using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnterState : State
{
    public override void Enter()
    {
        StartCoroutine(WaitToEnter());
    }

    private IEnumerator WaitToEnter()
    {
        GameManager._instance.FightScene.SetActive(true);

        CardCreator._instance.SpawnCardList();
        yield return new WaitForSeconds(3f);
        CardSystemManager._instance._MoveCardsSpawnedCards();
        yield return new WaitForSeconds(2f);
        foreach(Transform placedCard in GameManager._instance.CardSpawn.transform){
            placedCard.SetParent(CardSystemManager._instance.CardPilePos.transform);
            placedCard.transform.gameObject.SetActive(false);
        }
        foreach(Transform placedCard in GameManager._instance.CardSpawn.transform){
            placedCard.SetParent(CardSystemManager._instance.CardPilePos.transform);
            placedCard.transform.gameObject.SetActive(false);
        }
        foreach(Transform placedCard in GameManager._instance.CardSpawn.transform){
            placedCard.SetParent(CardSystemManager._instance.CardPilePos.transform);
            placedCard.transform.gameObject.SetActive(false);
        }
        foreach(Transform placedCard in GameManager._instance.CardSpawn.transform){
            placedCard.SetParent(CardSystemManager._instance.CardPilePos.transform);
            placedCard.transform.gameObject.SetActive(false);
            CardSystemManager._instance.UpdateChildCountUI();
        }
        myFSM.SetCurrentState(typeof(PlayerTurnState));
    }
}
