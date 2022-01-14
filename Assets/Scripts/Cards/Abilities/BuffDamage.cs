using UnityEngine;

[CreateAssetMenu(fileName = "BuffDamage", menuName = "Effects/BuffDamage")]
public class BuffDamage : BaseEffect
{
    public override void ApplyEffect()
    {
        //    BuffController._instance.BuffStats(template.cardDamageValue);
        BuffController._instance.BuffDamage();
        //AnimationController._instance.PlayParticleList(AnimationController._instance.PowerUpAttackBelle);
    }
}