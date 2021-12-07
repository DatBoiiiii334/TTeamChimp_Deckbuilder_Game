using System.Collections;
using UnityEngine;

public class PlayerWinState: State{

    public GameObject WinScreen;

    public override void Enter()
    {
        StartCoroutine(WaitEnter());
    }

    public override void Exit()
    {
        StartCoroutine(WaitExit());
    }

    private IEnumerator WaitEnter(){
        yield return new WaitForSeconds(2f);
        GameManager._instance.FightScene.SetActive(false);
        WinScreen.SetActive(true);
    }

    private IEnumerator WaitExit(){
        GameManager._instance.TransitionScreenAnim.SetTrigger("StartTransition");
        yield return new WaitForSeconds(2f);
        WinScreen.SetActive(false);
    }

    public void GoToMainMenu(){
        myFSM.SetCurrentState(typeof(MainMenuState));
    }

    public void Reset() {
        print("Reset");
        Player._player.ResetPlayerStats();
        EnemyBody._instanceEnemyBody.ResetEnemy();
        myFSM.SetCurrentState(typeof(PlayerEnterState));
    }
}
