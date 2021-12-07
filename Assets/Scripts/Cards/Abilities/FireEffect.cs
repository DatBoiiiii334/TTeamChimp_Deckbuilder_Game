using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FireEffect", menuName = "Effects/Fire")]
public class FireEffect : BaseEffect
{
    public override void ApplyEffect()
    {
        EnemyBody._instanceEnemyBody.forEnemyTicks += 1;
        //Apply Fire
        //TickManager._tickManager.forEnemyTicks += 3;
        //GameManager._instance.forEnemyTickDamage = template.card.AttackDamage;
        //TickManager._tickManager.ApplyTickToEnemy(template.card.AttackDamage);
        Debug.Log("Fire");
    }
}
