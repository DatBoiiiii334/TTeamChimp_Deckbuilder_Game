using System.Collections;
using UnityEngine;

public class MainMenuState : State
{
    public GameObject MainMenu;

    public override void Enter()
    {
        MainMenu.SetActive(true);
        
    }

    public void StartGame(){
        StartCoroutine(WaitForTransition());
    }

    public void QuitGame(){
        print("Quit");
        Application.Quit();
    }

    private IEnumerator WaitForTransition(){
        GameManager._instance.TransitionScreenAnim.SetTrigger("StartTransition");
        yield return new WaitForSeconds(2f);
        myFSM.SetCurrentState(typeof(GridMapState));
        MainMenu.SetActive(false);
    }
}
