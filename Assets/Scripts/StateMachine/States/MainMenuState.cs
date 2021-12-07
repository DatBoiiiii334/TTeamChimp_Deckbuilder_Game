using System.Collections;
using UnityEngine;

public class MainMenuState : State
{
    public GameObject MainMenu;

    public override void Enter()
    {
        MainMenu.SetActive(true);
    }

    public override void Exit()
    {
        StartCoroutine(WaitExit());
    }

    public void StartGame(){
        myFSM.SetCurrentState(typeof(PlayerEnterState));
    }

    public void QuitGame(){
        print("Quit");
        Application.Quit();
    }

    private IEnumerator WaitExit(){
        GameManager._instance.TransitionScreenAnim.SetTrigger("StartTransition");
        yield return new WaitForSeconds(1f);
        MainMenu.SetActive(false);
    }
}
