using System.Collections;
using UnityEngine;

public class EnemyTurnState : State
{
    public static EnemyTurnState _enemyTurnInstance;
    public int enemyState, myNextAttack;

    public override void Enter()
    {
        GameManager._instance.CardDeckBlocker.SetActive(true);
        if(EnemyBody._instanceEnemyBody.Health <= 0){
            myFSM.SetCurrentState(typeof(WinState));
        }else{
            StartCoroutine(ShowEnemyTurn());
        }
    }

    public void EnemyAttackTurn()
    {
        switch (EnemyBody._instanceEnemyBody.myNextAttack)
        {
            case 0:
                StartCoroutine(WaitToChangeIntent());
                ComidAttack(EnemyBody._instanceEnemyBody._core.basicAttack);
                FMODUnity.AudioManager._instance.TriggerSoundEffect(FMODUnity.AudioManager._instance.RedHoodAttack);
                Player._player.GetComponentInChildren<FeelsController>().TriggerFeelItem(Player._player.GetComponentInChildren<FeelsController>().Attacked);
                EnemyBody._instanceEnemyBody.GetComponentInChildren<FeelsController>().TriggerFeelItem(EnemyBody._instanceEnemyBody.GetComponentInChildren<FeelsController>().Attack);
                EnemyBody._instanceEnemyBody.EnemyTurn();
                break;

            case 1:
                StartCoroutine(WaitToChangeIntent());
                ComidRegenHeal(EnemyBody._instanceEnemyBody._core.maxBuff);
                 EnemyBody._instanceEnemyBody.EnemyTurn();
                break;

            case 2:
                StartCoroutine(WaitToChangeIntent());
                ComidAttack(EnemyBody._instanceEnemyBody._core.specialAttack);
                FMODUnity.AudioManager._instance.TriggerSoundEffect(FMODUnity.AudioManager._instance.RedHoodAttack);
                Player._player.GetComponentInChildren<FeelsController>().TriggerFeelItem(Player._player.GetComponentInChildren<FeelsController>().Attacked);
                EnemyBody._instanceEnemyBody.GetComponentInChildren<FeelsController>().TriggerFeelItem(EnemyBody._instanceEnemyBody.GetComponentInChildren<FeelsController>().Attack);
                EnemyBody._instanceEnemyBody.EnemyTurn();
                break;

            case 3:
                StartCoroutine(WaitToChangeIntent());
                ComidRegenShield(EnemyBody._instanceEnemyBody._core.maxBuff);
                EnemyBody._instanceEnemyBody.EnemyTurn();
                break;

            case 4:
                //Do feared animatie en sound design
                StartCoroutine(GoToNextState());
                 EnemyBody._instanceEnemyBody.EnemyTurn();
                StartCoroutine(WaitToChangeIntent());
                break;

            default:
                Debug.Log("Something went wrong");
                StartCoroutine(WaitToChangeIntent());
                break;
        }
    }

    public void ComidRegenShield(int shield)
    {
        //StartCoroutine(EnemyDoAction("Heal"));
        FMODUnity.AudioManager._instance.TriggerSoundEffect(FMODUnity.AudioManager._instance.Shield);
        EnemyBody._instanceEnemyBody.GetComponentInChildren<FeelsController>().TriggerFeelItem(EnemyBody._instanceEnemyBody.GetComponentInChildren<FeelsController>().Shield);
        EnemyBody._instanceEnemyBody.Shield += shield;
        if(EnemyBody._instanceEnemyBody.Shield + shield > EnemyBody._instanceEnemyBody._core.maxShield){
            EnemyBody._instanceEnemyBody.Shield = EnemyBody._instanceEnemyBody._core.maxShield;
        }

        EnemyBody._instanceEnemyBody.UpdateEnemyUI();
        StartCoroutine(GoToNextState());
        //EnemyBody._instanceEnemyBody.EnemyTurn();
    }

    public void ComidRegenHeal(int heal)
    {
        //StartCoroutine(EnemyDoAction("Heal"));
        FMODUnity.AudioManager._instance.TriggerSoundEffect(FMODUnity.AudioManager._instance.Heal);
        EnemyBody._instanceEnemyBody.GetComponentInChildren<FeelsController>().TriggerFeelItem(EnemyBody._instanceEnemyBody.GetComponentInChildren<FeelsController>().Heal);
        EnemyBody._instanceEnemyBody.Health += heal;
        if(EnemyBody._instanceEnemyBody.Health + heal > EnemyBody._instanceEnemyBody._core.maxHealth){
            EnemyBody._instanceEnemyBody.Health = EnemyBody._instanceEnemyBody._core.maxHealth;
        }
        EnemyBody._instanceEnemyBody.UpdateEnemyUI();
        StartCoroutine(GoToNextState());
        //EnemyBody._instanceEnemyBody.EnemyTurn();
    }

    public void ComidAttack(int damage)
    {
        Player._player.forPlayerTicks += 1;
        //StartCoroutine(EnemyAttackSequence());
        if (Player._player.Shield >= damage)
        {
            Player._player.Shield -= damage;
            Player._player.UpdatePlayerUI();
            StartCoroutine(GoToNextState());
            //EnemyBody._instanceEnemyBody.EnemyTurn();
        }
        else if (Player._player.Shield < damage)
        {
            int var;
            var = damage -= Player._player.Shield;
            Player._player.Health -= var;
            Player._player.Shield = 0;
            Player._player.UpdatePlayerUI();
            StartCoroutine(GoToNextState());
           // EnemyBody._instanceEnemyBody.EnemyTurn();

            if (Player._player.Health <= 0)
            {
                //GameManager._instance.LoseScreen.SetActive(true);
                myFSM.SetCurrentState(typeof(PlayerLoseState));
            }
        }
    }

    public void GoToPlayerState(){
        StopAllCoroutines();
        myFSM.SetCurrentState(typeof(ApplyEnemyTicksOnPlayerState));
    }

    IEnumerator WaitToChangeIntent(){
        yield return new WaitForSeconds(2f);
        EnemyBody._instanceEnemyBody.EnemyTurn();
    }

    IEnumerator EnemyAttackSequence(){
        AnimationController._instance.EnemyBasicAttackAnim();
        yield return new WaitForSeconds(0.5f);
        AnimationController._instance.PlayerHitAnim();
    }

    IEnumerator EnemyDoAction(string whatDo)
    {
        yield return new WaitForSeconds(0.5f);
        EnemyBody._instanceEnemyBody.myAnimator.SetTrigger(whatDo);
        yield return null;
    }

    IEnumerator ShowEnemyTurn()
    {
        UIManager._instanceUI.UIBanner.SetActive(true);
        UIManager._instanceUI.Title.text = "Enemy Turn";
        UIManager._instanceUI.undertitle.text =  "";
        UIManager._instanceUI.BannerAnimator.SetTrigger("ActivateBanner");
        yield return new WaitForSeconds(3f);
        UIManager._instanceUI.UIBanner.SetActive(false);
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