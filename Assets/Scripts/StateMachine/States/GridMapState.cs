using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GridMapState : State
{
    public static GridMapState _instance;
    public GameObject MapVisuals;
    public List<EnemyCore> EnemyTypes;
    public Camera MainMenuCamera;

    private float CameraFieldOfView;
    //private float speed = 100f;
    public bool IntroHasAlreadyHappend;

    public override void Enter()
    {
        CameraFieldOfView = MainMenuCamera.fieldOfView;
        GameManager._instance.FightScene.SetActive(false);
        GameManager._instance.ShopScene.SetActive(false);
        // if(IntroHasAlreadyHappend == false){
        //     StartCoroutine(WaitForBookAnim(1.5f));
        //     //IntroHasAlreadyHappend = true;
        //     MainMenuState._instance.MainMenu.SetActive(true);
        //     //GameManager._instance.TransitionScreenAnim.SetBool("STAYOPEN", true);
        // }else{
            MapVisuals.SetActive(true);
            MainMenuCamera.fieldOfView = 30f;
            GameManager._instance.OpenBookAnim.SetTrigger("OpenBook");
            MainMenuState._instance.MainMenu.SetActive(true);
        //}
        FMODUnity.AudioManager._instance.ChangeThemeSong(2);
    }

    public override void Exit(){
        MainMenuCamera.fieldOfView = CameraFieldOfView;
        MapVisuals.SetActive(false);
        MainMenuState._instance.GameScene.SetActive(true);
    }

    public void ChangeEnemy()
    {
        int var = Random.Range(0, EnemyTypes.Count);
        EnemyBody._instanceEnemyBody._core = EnemyTypes[var];
        StartCoroutine(TransitionToFightScene());
    }

    public void PickEnemyEncounter(int enemyType){
        EnemyBody._instanceEnemyBody._core = EnemyTypes[enemyType];
        StartCoroutine(TransitionToFightScene());
    }

    public void GoToStore()
    {
        StartCoroutine(TransitionToShopScene());
    }

    public IEnumerator WaitForBookAnim(float waitAmount){
        //MainMenuState._instance.MainMenuItems.SetActive(false);
        yield return new WaitForSeconds(waitAmount);
        // // MapVisuals.SetActive(true);
        
        // //MainMenuCamera.fieldOfView = 30f;

        // float elapsed = 0.0f;
        // while (elapsed < waitAmount )
        // {
        //     MainMenuCamera.fieldOfView = Mathf.Lerp( startAmount, EndAmount, elapsed / waitAmount );
        //     elapsed += Time.deltaTime;
        //     yield return null;
        // }
        // MainMenuCamera.fieldOfView = EndAmount;
        MapVisuals.SetActive(true);
    }

    public IEnumerator TransitionToFightScene()
    {
        GameManager._instance.TransitionScreenAnim.SetTrigger("StartTransition");
        MapVisuals.SetActive(false);
        yield return new WaitForSeconds(1f);
        
        //yield return new WaitForSeconds(0.5f);
        myFSM.SetCurrentState(typeof(PlayerEnterState));
        MapVisuals.SetActive(false);
        GameManager._instance.TransitionScreenAnim.SetBool("STAYOPEN", true);
        MainMenuState._instance.MainMenu.SetActive(false);
    }

    public IEnumerator TransitionToShopScene()
    {
        GameManager._instance.TransitionScreenAnim.SetBool("STAYOPEN", true);
        GameManager._instance.TransitionScreenAnim.SetTrigger("StartTransition");
        yield return new WaitForSeconds(2f);
        myFSM.SetCurrentState(typeof(ShopState));
        MapVisuals.SetActive(false);
    }

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
        }
    }
}
