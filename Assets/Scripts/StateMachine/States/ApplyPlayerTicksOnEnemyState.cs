using System.Collections;
using UnityEngine;

public class ApplyPlayerTicksOnEnemyState : State
{
    public static ApplyPlayerTicksOnEnemyState _PlayerToEnemyTickInstance;

    public override void Enter()
    {
        if(EnemyBody._instanceEnemyBody.forEnemyTicks > 0){
            StartCoroutine(DoTimedAction());
        }else{
            myFSM.SetCurrentState(typeof(EnemyTurnState));
        }
    }

    public override void Exit()
    {
    }

    public void TickDamageToEnemy(int tickDmg)
    {
        EnemyBody._instanceEnemyBody.Health -= tickDmg;
        EnemyBody._instanceEnemyBody.forEnemyTicks -= 1;
        EnemyBody._instanceEnemyBody.UpdateEnemyUI();
    }

    IEnumerator DoTimedAction(){
        yield return new WaitForSeconds(1f);
        EnemyBody._instanceEnemyBody.myAnimator.SetTrigger("BleedDmg");
        TickDamageToEnemy(GameManager._instance.forEnemyTickDamage);
        yield return new WaitForSeconds(1f);
        myFSM.SetCurrentState(typeof(EnemyTurnState));
    }

    private void Awake()
    {
        if (_PlayerToEnemyTickInstance != null)
        {
            Destroy(gameObject);
        }
        _PlayerToEnemyTickInstance = this;
    }
}