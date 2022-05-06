using UnityEngine;

[CreateAssetMenu(fileName = "ExplodeTicksEffect", menuName = "Effects/ExplodeTicksEffect")]
public class ExplodeTicksEffect : BaseEffect
{
    public override void ApplyEffect()
    {
        //int var;
        // var = TickManager._tickManager.forEnemyTicks * template.card.TickDamage;
        GameManager._instance.DamageEnemy(template.card.TickDamage);
        //TickManager._tickManager.forEnemyTicks = 0;
    }
}
