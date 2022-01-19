using UnityEngine;

[CreateAssetMenu(fileName = "HealPlayerEffect", menuName = "Effects/HealPlayer")]
public class HealPlayerEffect : BaseEffect
{
    public override void ApplyEffect()
    {
        if(Player._player.Health == Player._player.maxHealth){
            Player._player.anim.SetTrigger("DoHealAnim");
            Debug.Log("Used HEAL, but already at max hp");
            return;
        }
        Debug.Log("Used HEAL");
        Player._player.Health += template.card.Health;
        if(Player._player.Health + template.card.Health > Player._player.maxHealth){
            Player._player.Health = Player._player.maxHealth;
        }
        Player._player.anim.SetTrigger("DoHealAnim");
        Player._player.UpdatePlayerUI();
        EnemyBody._instanceEnemyBody.UpdateEnemyUI();
    }
}