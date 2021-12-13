using System.Collections;
using UnityEngine;

public class PlayerTurnState : State
{
    public GameObject CardDeckBlocker;
    public int PlayerTurnAmount;

    public override void Enter()
    {
        if (Player._player.Health <= 0)
        {
            StopAllCoroutines();
            myFSM.SetCurrentState(typeof(PlayerLoseState));
        }
        GameManager._instance.FightScene.SetActive(true);
        StartCoroutine(ShowPlayerTurn());
    }

    public override void Exit()
    {
        CardDeckBlocker.SetActive(true);
        StartCoroutine(ClearDeck());
    }

    public void NextTurn()
    {
        myFSM.SetCurrentState(typeof(ApplyPlayerTicksOnEnemyState));
    }

    public void GivePlayerTurn()
    {
        Player._player.Mana = 5;
        Player._player.UpdatePlayerUI();
        CardDeckBlocker.SetActive(false);
        UIManager._instanceUI.UIBanner.SetActive(false);
        StopAllCoroutines();
        StartCoroutine(WaitForCards());
    }

    IEnumerator ShowPlayerTurn()
    {
        PlayerTurnAmount += 1;
        UIManager._instanceUI.UIBanner.SetActive(true);
        UIManager._instanceUI.Title.text = "Player Turn";
        UIManager._instanceUI.undertitle.text = PlayerTurnAmount + "th turn";
        UIManager._instanceUI.BannerAnimator.SetTrigger("ActivateBanner");
        yield return new WaitForSeconds(2.4f);
        GivePlayerTurn();
    }

    IEnumerator WaitForCards()
    {
        if (CardSystemManager._instance.CardDiscardPilePos.transform.childCount >= 10)
        {
            for (int i = 0; i < CardSystemManager._instance.CardDiscardPilePos.transform.childCount; i++)
            {
                CardSystemManager._instance._MoveCardsToPile(CardSystemManager._instance.CardDiscardPilePos.transform.GetChild(i));
                yield return null;
            }
            yield return new WaitForSeconds(1.5f);
            CardSystemManager._instance._MoveCardsToDeck();
            yield return null;
        }
        else
        {
            CardSystemManager._instance._MoveCardsToDeck();
            StopCoroutine(WaitForCards());
        }
    }

    IEnumerator ClearDeck()
    {
        for (int i = 0; i < CardSystemManager._instance.CardDeckPos.transform.childCount; i++)
        {
            CardSystemManager._instance._MoveCardsToDiscard(CardSystemManager._instance.CardDeckPos.transform.GetChild(i));
            yield return null;
        }
    }
}
