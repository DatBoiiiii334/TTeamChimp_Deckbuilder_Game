
using UnityEngine;

[CreateAssetMenu(fileName = "RawDamageEffect", menuName = "Effects/Raw Damage")]
public class RawDamageEffect : BaseEffect
{
    public override void ApplyEffect()
    {
        Debug.Log("RawDamageEffect");
        GameManager._instance.DamageEnemy(template.cardDamageValue);
        //FeelsController._instance.TriggerFeelItem(FeelsController._instance.BelleFeels,1);
        Player._player.GetComponentInChildren<FeelsController>().TriggerFeelItem(Player._player.GetComponentInChildren<FeelsController>().Attack);
        EnemyBody._instanceEnemyBody.GetComponentInChildren<FeelsController>().TriggerFeelItem(EnemyBody._instanceEnemyBody.GetComponentInChildren<FeelsController>().Attacked);
        FMODUnity.AudioManager._instance.TriggerSoundEffect(FMODUnity.AudioManager._instance.BelleAttacks);
        //string gay = EnemyBody._instanceEnemyBody._core.name;
        //FeelsController._instance.TriggerFeelItem(FeelsController._instance.BelleFeels,1);
        Debug.Log("DamageDone: " + template.cardDamageValue + " with " + template.card.Name);
    }
}