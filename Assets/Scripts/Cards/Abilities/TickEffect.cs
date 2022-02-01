using UnityEngine;

[CreateAssetMenu(fileName = "TickEffect", menuName = "Effects/TickDmg")]
public class TickEffect : BaseEffect
{
    public override void ApplyEffect()
    {
        EnemyBody._instanceEnemyBody.forEnemyTicks += 1;
        EnemyBody._instanceEnemyBody.GiveBleed();
        //ApplyPlayerTicksOnEnemyState._PlayerToEnemyTickInstance.TickDamageToEnemy(template.card.AttackDamage);
    }
}
