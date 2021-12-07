using UnityEngine;

[CreateAssetMenu(fileName = "VampiricEffect", menuName = "Effects/VampiricEffect")]
public class VampiricEffect : BaseEffect
{
    public override void ApplyEffect()
    {
        EnemyBody._instanceEnemyBody.forEnemyTicks += 1;
        if (EnemyBody._instanceEnemyBody.Shield <= 0)
        { 
            Player._player.Health += EnemyBody._instanceEnemyBody.lastDamageDealtTo;
            GameManager._instance.DamageEnemy(template.card.AttackDamage);
            EnemyBody._instanceEnemyBody.lastDamageDealtTo = 0;
            Player._player.anim.SetTrigger("DoAttackAnim");
        }
        else
        {
            Player._player.anim.SetTrigger("DoAttackAnim");
        }
    }
}