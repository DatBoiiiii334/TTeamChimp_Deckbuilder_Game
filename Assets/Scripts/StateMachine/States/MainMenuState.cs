using System.Collections;
using UnityEngine;

public class MainMenuState : State
{
    public static MainMenuState _instance;
    public GameObject MainMenu;
    private bool hasThemeBegan;

    public override void Enter()
    {
        MainMenu.SetActive(true);
        if(hasThemeBegan == false){
            FMODUnity.AudioManager._instance.StartMainTheme();
            hasThemeBegan = true;
        }
        FMODUnity.AudioManager._instance.ChangeThemeSong(0);
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

    private void Awake() {
        if(_instance != null){
            Destroy(gameObject);
        }else{
            _instance = this;
        }
    }
}
