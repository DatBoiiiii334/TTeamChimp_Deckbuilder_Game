using UnityEngine;

[CreateAssetMenu(fileName = "FearedEffect", menuName = "Effects/Feared")]
public class FearedEffect : BaseEffect
{
    public override void ApplyEffect()
    {
        Debug.Log("FearedEffect");
        EnemyBody._instanceEnemyBody.myNextAttack = 4;;
        EnemyBody._instanceEnemyBody.EnemyIntend(4);
    }
}