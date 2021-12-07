using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VampiricStrike : MonoBehaviour
{
    private CardTemplate myCardTemplate;

    void Start()
    {
        myCardTemplate = GetComponent<CardTemplate>();
        myCardTemplate.myCardSpells += VampiricAbilitie;
    }

    public void VampiricAbilitie()
    {
        if (EnemyBody._instanceEnemyBody.Shield <= 0)
        {
            EnemyBody._instanceEnemyBody.Health -= myCardTemplate.card.AttackDamage;
            Player._player.Health += EnemyBody._instanceEnemyBody.lastDamageDealtTo;
            EnemyBody._instanceEnemyBody.lastDamageDealtTo = 0;
            Player._player.anim.SetTrigger("DoAttackAnim");
            Player._player.UpdatePlayerUI();
            EnemyBody._instanceEnemyBody.UpdateEnemyUI();
        }
        else
        {
            Player._player.anim.SetTrigger("DoAttackAnim");
            Player._player.UpdatePlayerUI();
            EnemyBody._instanceEnemyBody.UpdateEnemyUI();
        }
    }
}
