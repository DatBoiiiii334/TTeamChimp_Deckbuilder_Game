using UnityEngine;

[CreateAssetMenu(fileName = "MissingHpDmgEffect", menuName = "Effects/MissingHpDmg")]
public class PercentMissingHPEffect : BaseEffect
{
    public override void ApplyEffect()
    {
        int var;
        var = Player._player.maxHealth - Player._player.Health;
        var /= 2;
        var += template.cardDamageValue;
        GameManager._instance.DamageEnemy(var);
        Debug.Log("MissingHpDmg: " + var);
    }
}
