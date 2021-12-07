using UnityEngine;

[CreateAssetMenu(fileName = "FearedEffect", menuName = "Effects/Feared")]
public class FearedEffect : BaseEffect
{
    public override void ApplyEffect()
    {
        Debug.Log("FearedEffect");
        EnemyBody._instanceEnemyBody.enemyState = 4;
    }
}
