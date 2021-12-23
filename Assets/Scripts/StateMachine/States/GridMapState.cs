using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GridMapState : State
{

    public static GridMapState _instance;
    public GameObject MapVisuals;
    public List<EnemyCore> EnemyTypes;
    public override void Enter()
    {
        print("GridMapState");
        MapVisuals.SetActive(true);
    }

    public void ChangeEnemy()
    {
        int var = Random.Range(0, EnemyTypes.Count);
        EnemyBody._instanceEnemyBody._core = EnemyTypes[var];
        StartCoroutine(TransitionToFightScene());
    }

    public void GoToStore()
    {
        StartCoroutine(TransitionToShopScene());
    }

    public IEnumerator TransitionToFightScene()
    {
        GameManager._instance.TransitionScreenAnim.SetTrigger("StartTransition");
        yield return new WaitForSeconds(2f);
        myFSM.SetCurrentState(typeof(PlayerEnterState));
        MapVisuals.SetActive(false);
    }

    public IEnumerator TransitionToShopScene()
    {
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
