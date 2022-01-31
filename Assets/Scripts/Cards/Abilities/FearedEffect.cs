using UnityEngine;

[CreateAssetMenu(fileName = "FearedEffect", menuName = "Effects/Feared")]
public class FearedEffect : BaseEffect
{
    public override void ApplyEffect()
    {
        Debug.Log("FearedEffect");
        EnemyBody._instanceEnemyBody.myNextAttack = 4;;
        EnemyBody._instanceEnemyBody.EnemyIntend(4);
        //Player._player.GetComponentInChildren<FeelsController>().TriggerFeelItem(Player._player.GetComponentInChildren<FeelsController>().magicAttacked);
        //EnemyBody._instanceEnemyBody.GetComponentInChildren<FeelsController>().TriggerFeelItem(EnemyBody._instanceEnemyBody.GetComponentInChildren<FeelsController>().Attacked);
    }
}