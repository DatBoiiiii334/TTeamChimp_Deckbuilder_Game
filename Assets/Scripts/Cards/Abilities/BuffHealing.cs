using UnityEngine;

[CreateAssetMenu(fileName = "BuffHealing", menuName = "Effects/BuffHealing")]
public class BuffHealing : BaseEffect
{
    public override void ApplyEffect()
    {
        //    BuffController._instance.BuffStats(template.cardDamageValue);
        BuffController._instance.BuffHealing();
        AnimationController._instance.PlayParticleList(AnimationController._instance.UtilityParticleBelle);
    }
}
