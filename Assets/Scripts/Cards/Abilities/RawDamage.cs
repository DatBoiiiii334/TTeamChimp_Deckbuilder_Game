using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RawDamage : MonoBehaviour
{
    private CardTemplate myCardTemplate;

    void Start()
    {
        myCardTemplate = GetComponent<CardTemplate>();
        myCardTemplate.myCardSpells += RawDamageAbility;
    }

    public void RawDamageAbility()
    {
        if (myCardTemplate.card.AttackDamage > EnemyBody._instanceEnemyBody.Shield)
        {
            int var;
            int kaartDamage = myCardTemplate.card.AttackDamage;
            Player._player.anim.SetTrigger("DoAttackAnim");
            var = kaartDamage -= EnemyBody._instanceEnemyBody.Shield;
            EnemyBody._instanceEnemyBody.Shield = 0;
            EnemyBody._instanceEnemyBody.Health -= var;
            EnemyBody._instanceEnemyBody.lastDamageDealtTo = myCardTemplate.card.AttackDamage;
            Player._player.UpdatePlayerUI();
            EnemyBody._instanceEnemyBody.UpdateEnemyUI();
        }
        else if (myCardTemplate.card.AttackDamage <= EnemyBody._instanceEnemyBody.Shield)
        {
            Player._player.anim.SetTrigger("DoAttackAnim");
            EnemyBody._instanceEnemyBody.Shield -= myCardTemplate.card.AttackDamage;
            EnemyBody._instanceEnemyBody.lastDamageDealtTo = myCardTemplate.card.AttackDamage;
            Player._player.UpdatePlayerUI();
            EnemyBody._instanceEnemyBody.UpdateEnemyUI();
        }
    }
}
