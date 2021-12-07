using UnityEngine;

[CreateAssetMenu(fileName = "RawDamageEffect", menuName = "Effects/Raw Damage")]
public class RawDamageEffect : BaseEffect
{
    public override void ApplyEffect()
    {
        Debug.Log("RawDamageEffect");
        GameManager._instance.DamageEnemy(template.card.AttackDamage);
    }
}