using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GridMapState: State{

    public static GridMapState _instance;
    public GameObject MapVisuals;
    public List<EnemyCore> EnemyTypes;
    public override void Enter()
    {
        print("GridMapState");
        MapVisuals.SetActive(true);
    }

    public override void Exit()
    {
        StartCoroutine(OnExit());
    }

    public void ChangeEnemy(){
        // EnemyBody._instanceEnemyBody._core = EnemyTypes[Random.Range(0,EnemyTypes.Count)];
        EnemyBody._instanceEnemyBody._core = EnemyTypes[3];
        myFSM.SetCurrentState(typeof(PlayerEnterState));
    }

    public void GoToStore(){
        //EnemyBody._instanceEnemyBody._core = EnemyTypes[Random.Range(0,EnemyTypes.Count)];
        myFSM.SetCurrentState(typeof(ShopState));
    }

    public IEnumerator OnExit(){
        GameManager._instance.TransitionScreenAnim.SetTrigger("StartTransition");
        yield return new WaitForSeconds(2f);
        MapVisuals.SetActive(false);
    }

    private void Awake() {
        if(_instance != null){
            Destroy(gameObject);
        }else{
            _instance = this;
        }
    }
}
