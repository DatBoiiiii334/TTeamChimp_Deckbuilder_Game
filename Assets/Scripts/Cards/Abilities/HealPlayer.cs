using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPlayer : MonoBehaviour
{
    private CardTemplate myCardTemplate;

    void Start()
    {
        myCardTemplate = GetComponent<CardTemplate>();
        myCardTemplate.myCardSpells += HealingAction;
    }

    public void HealingAction()
    {
        Player._player.Health += myCardTemplate.card.Health;
        Player._player.Shield += myCardTemplate.card.Shield;
        Player._player.anim.SetTrigger("DoHealAnim");
        Player._player.UpdatePlayerUI();
        EnemyBody._instanceEnemyBody.UpdateEnemyUI();
    }
}
