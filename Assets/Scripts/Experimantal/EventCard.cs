using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventCard : MonoBehaviour, IDamageCard
{
    public int cardAttackValue, cardManaCost;
    private Card _cardObject;
    //private TestManager 

    private void Start()
    {
        //_cardObject = GetComponent<Card>();
        //_TestManager = TestManager._instance;
    }

    void OnEnable()
    {
        EventManager.OnCardAction += doDamage;
        print("EventCard");
        //EnemyEventField.OnCardActionEnemy += doDamage;
    }

    void OnDisable()
    {
        EventManager.OnCardAction -= doDamage;
        //EnemyEventField.OnCardActionEnemy -= doDamage;
    }

    public void doDamage()
    {
        Attack(cardAttackValue, cardManaCost, TestManager._instance.EnemyLastDamageTaken);
    }

    void Attack(int cardDamage, int cardManaCost, int enemyLastDamageTaken)
    {
        if (cardDamage > TestManager._instance.EnemyShield)
        {
            int var;
            int kaartDamage = cardDamage;
            var = cardDamage -= TestManager._instance.EnemyShield;
            TestManager._instance.EnemyShield = 0;
            TestManager._instance.EnemyHP -= var;
            TestManager._instance.PlayerManaAmount -= cardManaCost;
            enemyLastDamageTaken = cardDamage;
        }
        else if (cardDamage <= TestManager._instance.EnemyShield)
        {
            TestManager._instance.EnemyShield -= cardDamage;
            TestManager._instance.PlayerManaAmount -= cardManaCost;
        }
    }
}
