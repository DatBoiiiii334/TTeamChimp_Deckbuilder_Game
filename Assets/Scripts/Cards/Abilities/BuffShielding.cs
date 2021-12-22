using UnityEngine;

[CreateAssetMenu(fileName = "BuffShielding", menuName = "Effects/BuffShielding")]
public class BuffShielding : BaseEffect
{
    public override void ApplyEffect()
    {
        //    BuffController._instance.BuffStats(template.cardDamageValue);
        BuffController._instance.BuffShielding();
        AnimationController._instance.PlayParticleList(AnimationController._instance.ShieldParticleBelle);
    }
}
