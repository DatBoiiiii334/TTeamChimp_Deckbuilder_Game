using UnityEngine;

[CreateAssetMenu(fileName = "ExplodeTicksEffect", menuName = "Effects/ExplodeTicks")]
public class ExplodeTicksEffect : BaseEffect
{
    public override void ApplyEffect()
    {
        int var;
        var = TickManager._tickManager.forEnemyTicks * template.card.TickDamage;
        GameManager._instance.DamageEnemy(var);
        TickManager._tickManager.forEnemyTicks = 0;
    }
}
