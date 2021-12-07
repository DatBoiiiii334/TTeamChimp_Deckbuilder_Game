using System.Collections;
using UnityEngine;

public class PlayerLoseState: State{
    public GameObject LoseScreen;

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
        LoseScreen.SetActive(true);
    }

    private IEnumerator WaitExit(){
        GameManager._instance.TransitionScreenAnim.SetTrigger("StartTransition");
        yield return new WaitForSeconds(2f);
        LoseScreen.SetActive(false);
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
