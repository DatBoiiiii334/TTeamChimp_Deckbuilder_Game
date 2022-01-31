using System.Collections;
using UnityEngine;

public class ApplyEnemyTicksOnPlayerState : State
{
    public static ApplyEnemyTicksOnPlayerState _EnemyToPlayerTickInstance;

    public override void Enter()
    {
        GameManager._instance.CardDeckBlocker.SetActive(true);
        if (Player._player.forPlayerTicks > 0)
        {
            StartCoroutine(DoTimedAction());
        }
        else
        {
            myFSM.SetCurrentState(typeof(PlayerTurnState));
        }
    }

    public override void Exit()
    {
        GameManager._instance.CardDeckBlocker.SetActive(false);
        StopCoroutine(DoTimedAction());
    }

    public void TickDamageToPlayer(int tickDmg)
    {
        //Player._player.anim.SetTrigger("TakeDMG");
        Player._player.GetComponentInChildren<FeelsController>().TriggerFeelItem(Player._player.GetComponentInChildren<FeelsController>().Attacked);
        Player._player.Health -= tickDmg;
        Player._player.forPlayerTicks -= 1;
        Player._player.UpdatePlayerUI();
    }

    IEnumerator DoTimedAction()
    {
        yield return new WaitForSeconds(1f);
        TickDamageToPlayer(Player._player.tickforPlayerDmg);
        yield return new WaitForSeconds(1f);
        myFSM.SetCurrentState(typeof(PlayerTurnState));
    }

    private void Awake()
    {
        if (_EnemyToPlayerTickInstance != null)
        {
            Destroy(gameObject);
        }
        _EnemyToPlayerTickInstance = this;
    }
}
