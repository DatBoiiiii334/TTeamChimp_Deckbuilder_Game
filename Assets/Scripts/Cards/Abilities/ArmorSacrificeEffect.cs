using UnityEngine;

[CreateAssetMenu(fileName = "ArmorSacrificeEffect", menuName = "Effects/ArmorSacrifice")]
public class ArmorSacrificeEffect : BaseEffect
{
    public override void ApplyEffect()
    {
       Player._player.Shield -= template.cardDamageValue;
       GameManager._instance.DamageEnemy(template.cardDamageValue);
    }
}