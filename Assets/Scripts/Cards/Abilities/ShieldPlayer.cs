using UnityEngine;

[CreateAssetMenu(fileName = "ShieldPlayerEffect", menuName = "Effects/ShieldPlayer")]
public class ShieldPlayer : BaseEffect
{
    public override void ApplyEffect()
    {
        Debug.Log("Used Shield");
        Player._player.Shield += template.card.Shield;
        Player._player.anim.SetTrigger("DoHealAnim");
        Player._player.UpdatePlayerUI();
        EnemyBody._instanceEnemyBody.UpdateEnemyUI();
    }
}
