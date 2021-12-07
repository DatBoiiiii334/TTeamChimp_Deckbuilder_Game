using System.Collections;
using UnityEngine;

public class EnemyTurnState : State
{
    public static EnemyTurnState _enemyTurnInstance;
    public GameObject CardDeckBlocker;
    public int enemyState, myNextAttack;

    public override void Enter()
    {
        CardDeckBlocker.SetActive(true);
        if(EnemyBody._instanceEnemyBody.Health <= 0){
            myFSM.SetCurrentState(typeof(PlayerWinState));
        }else{
            StartCoroutine(ShowEnemyTurn());
        }
    }

    public override void Exit()
    {}

    public void EnemyAttackTurn()
    {
        UIManager._instanceUI.UIBanner.SetActive(false);
        switch (EnemyBody._instanceEnemyBody.myNextAttack)
        {
            case 0:
                ComidAttack(EnemyBody._instanceEnemyBody._core.basicAttack, "BasicAttack");
                EnemyBody._instanceEnemyBody.EnemyTurn();
                break;

            case 1:
                ComidRegen(EnemyBody._instanceEnemyBody._core.maxBuff, 0);
                EnemyBody._instanceEnemyBody.EnemyTurn();
                break;

            case 2:
                ComidAttack(EnemyBody._instanceEnemyBody._core.specialAttack, "BasicAttack");
                EnemyBody._instanceEnemyBody.EnemyTurn();
                break;

            case 3:
                ComidRegen(0, EnemyBody._instanceEnemyBody._core.maxBuff);
                EnemyBody._instanceEnemyBody.EnemyTurn();
                break;

            case 4:
                //Doe feared animatie en sound design
                EnemyBody._instanceEnemyBody.EnemyTurn();
                break;

            default:
                Debug.Log("Something went wrong");
                break;
        }
    }

    public void ComidRegen(int heal, int shield)
    {
        StartCoroutine(EnemyDoAction("Heal"));
        EnemyBody._instanceEnemyBody.Shield += shield;
        EnemyBody._instanceEnemyBody.Health += heal;
        EnemyBody._instanceEnemyBody.UpdateEnemyUI();
        StartCoroutine(GoToNextState());
    }

    public void ComidAttack(int damage, string call)
    {
        Player._player.forPlayerTicks += 1;
        StartCoroutine(EnemyDoAction(call));
        if (Player._player.Shield >= damage)
        {
            Player._player.Shield -= damage;
            Player._player.UpdatePlayerUI();
            StartCoroutine(GoToNextState());
        }
        else if (Player._player.Shield < damage)
        {
            int var;
            var = damage -= Player._player.Shield;
            Player._player.Health -= var;
            Player._player.Shield = 0;
            Player._player.UpdatePlayerUI();
            StartCoroutine(GoToNextState());

            if (Player._player.Health <= 0)
            {
                GameManager._instance.LoseScreen.SetActive(true);
            }
        }
    }

    public void GoToPlayerState(){
        StopAllCoroutines();
        myFSM.SetCurrentState(typeof(ApplyEnemyTicksOnPlayerState));
    }

    IEnumerator EnemyDoAction(string whatDo)
    {
        EnemyBody._instanceEnemyBody.myAnimator.SetTrigger(whatDo);
        yield return new WaitForSeconds(0.5f);
    }

    IEnumerator ShowEnemyTurn()
    {
        UIManager._instanceUI.UIBanner.SetActive(true);
        UIManager._instanceUI.Title.text = "Enemy Turn";
        UIManager._instanceUI.undertitle.text =  "";
        UIManager._instanceUI.BannerAnimator.SetTrigger("ActivateBanner");
        yield return new WaitForSeconds(3f);
        EnemyAttackTurn();
        StopCoroutine(ShowEnemyTurn());
    }

    IEnumerator GoToNextState(){
        yield return new WaitForSeconds(1.5f);
        GoToPlayerState();
    }

    private void Awake()
    {
        if (_enemyTurnInstance != null)
        {
            Destroy(gameObject);
        }
        _enemyTurnInstance = this;
    }
}