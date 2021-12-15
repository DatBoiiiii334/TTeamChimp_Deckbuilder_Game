using UnityEngine;

[CreateAssetMenu(fileName = "ShieldPlayerEffect", menuName = "Effects/ShieldPlayer")]
public class ShieldPlayerEffect : BaseEffect
{
    public override void ApplyEffect()
    {
        Debug.Log("Used Shield");
        Player._player.Shield += template.card.Shield;
        Player._player.anim.SetTrigger("DoHealAnim");
        AnimationController._instance.PlayParticleList(AnimationController._instance.ShieldParticleBelle);
        Player._player.UpdatePlayerUI();
        EnemyBody._instanceEnemyBody.UpdateEnemyUI();
    }
}
