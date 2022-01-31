using System.Collections;
using UnityEngine;
using MoreMountains.Feedbacks;
using MoreMountains.FeedbacksForThirdParty;
using MoreMountains.Tools;

public class MainMenuState : State
{
    public static MainMenuState _instance;
    public GameObject MainMenu, MainMenuItems, GameScene;
    public MMFeedbacks FadeOutIntroText, FadeInIntroText;
    private bool hasThemeBegan;

    public override void Enter()
    {
        GameScene.SetActive(false);
        MainMenu.SetActive(true);
        MainMenuItems.SetActive(true);
        FadeInIntroText.PlayFeedbacks();

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
        // GameManager._instance.TransitionScreenAnim.SetTrigger("StartTransition");
        //GameManager._instance.OpenBookAnim.SetTrigger("OpenBook");
        FadeOutIntroText.PlayFeedbacks();//
        //GameManager._instance.OpenBookAnim.SetBool("BookOpen", true);
        yield return new WaitForSeconds(1f);
        FMODUnity.AudioManager._instance.TriggerSoundEffect(FMODUnity.AudioManager._instance.BookOpening);
        
        yield return new WaitForSeconds(1f);
        //MainMenuItems.SetActive(false);
        // IntroText.PlayFeedbacks();//
        yield return new WaitForSeconds(1f);
        myFSM.SetCurrentState(typeof(GridMapState));
        MainMenuItems.SetActive(false);
        //MainMenu.SetActive(false);
        
    }

    private void Awake() {
        if(_instance != null){
            Destroy(gameObject);
        }else{
            _instance = this;
        }
    }
}
