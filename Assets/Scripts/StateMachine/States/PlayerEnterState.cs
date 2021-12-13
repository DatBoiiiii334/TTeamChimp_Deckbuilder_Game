using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnterState : State
{
    public override void Enter()
    {
        GameManager._instance.CardDeckBlocker.SetActive(true);
        EnemyBody._instanceEnemyBody.ResetEnemy();
        Player._player.ResetPlayerStats();
        //EnemyBody._instanceEnemyBody._core = GridMapState._instance.EnemyTypes[2];
        EnemyBody._instanceEnemyBody.SpawnEnemy();
        if(CardSystemManager._instance.CardDeckPos.transform.childCount > 0){
            foreach(Transform _card in CardSystemManager._instance.CardDeckPos.transform){
                Destroy(_card.transform.gameObject);
            }
        }
        if(CardSystemManager._instance.CardPilePos.transform.childCount > 0){
            foreach(Transform _card in CardSystemManager._instance.CardPilePos.transform){
                Destroy(_card.transform.gameObject);
            }
        }
        if(CardSystemManager._instance.CardDiscardPilePos.transform.childCount > 0){
            foreach(Transform _card in CardSystemManager._instance.CardDiscardPilePos.transform){
                Destroy(_card.transform.gameObject);
            }
        }
        StartCoroutine(WaitToEnter());
    }
    public override void Exit()
    {
        GameManager._instance.CardDeckBlocker.SetActive(false);
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
