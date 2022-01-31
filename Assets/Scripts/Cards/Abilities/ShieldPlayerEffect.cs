using UnityEngine;

[CreateAssetMenu(fileName = "ShieldPlayerEffect", menuName = "Effects/ShieldPlayer")]
public class ShieldPlayerEffect : BaseEffect
{
    public override void ApplyEffect()
    {
        Debug.Log("Used Shield");
        Player._player.Shield += template.card.Shield;
        Player._player.GetComponentInChildren<FeelsController>().TriggerFeelItem(Player._player.GetComponentInChildren<FeelsController>().Shield);
        //Player._player.anim.SetTrigger("DoHealAnim");
        //AnimationController._instance.PlayParticleList(AnimationController._instance.ShieldParticleBelle);
        //AnimationController._instance.playWithDelay(0,0,AnimationController._instance.ShieldParticleBelle, FMODUnity.AudioManager._instance.ShieldSoundeffect);
        Player._player.UpdatePlayerUI();
        EnemyBody._instanceEnemyBody.UpdateEnemyUI();
    }
}
