using UnityEngine;

[CreateAssetMenu(fileName = "HealPlayerEffect", menuName = "Effects/HealPlayer")]
public class HealPlayerEffect : BaseEffect
{
    public override void ApplyEffect()
    {
        Player._player.Health += template.card.Health;
        Player._player.Shield += template.card.Shield;
        Player._player.anim.SetTrigger("DoHealAnim");
        Player._player.UpdatePlayerUI();
        EnemyBody._instanceEnemyBody.UpdateEnemyUI();
    }
}
