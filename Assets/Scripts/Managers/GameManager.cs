using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager _instance;
    public GameObject CardSpawn, winScreen, LoseScreen, FightScene, ShopScene;
    public int forEnemyTickDamage, amountCardsSpawn;
    FSM myFSM;

    public Animator TransitionScreenAnim, ShopAnim;

    public void Start()
    {
        myFSM = GetComponent<FSM>();
        State[] myStatearray = GetComponents<State>();
        foreach (State state in myStatearray)
        {
            myFSM.Add(state.GetType(), state);
        }
        myFSM.SetCurrentState(typeof(MainMenuState));
    }

    public void isEnemyDead()
    {
        if (EnemyBody._instanceEnemyBody.Health <= 0)
        {
            winScreen.SetActive(true);
            CardPicker.instance_CardPicker.OpenNewCardsWindow();
        }
    }

    public void DamageEnemy(int damage)
    {
        if (damage >= EnemyBody._instanceEnemyBody.Shield)
        {
            int var;
            int kaartDamage = damage;
            Player._player.anim.SetTrigger("DoAttackAnim");
            var = kaartDamage -= EnemyBody._instanceEnemyBody.Shield;
            EnemyBody._instanceEnemyBody.Shield = 0;
            EnemyBody._instanceEnemyBody.Health -= var;
            EnemyBody._instanceEnemyBody.lastDamageDealtTo = var;
            Debug.Log("damage to enemy: " + var);
        }
        else if (damage < EnemyBody._instanceEnemyBody.Shield)
        {
            Player._player.anim.SetTrigger("DoAttackAnim");
            EnemyBody._instanceEnemyBody.Shield -= damage;
            EnemyBody._instanceEnemyBody.lastDamageDealtTo = damage;
        }
    }

    public void TickDmg(int damage)
    {
        if (TickManager._tickManager.forEnemyTicks > 0)
        {
            TickManager._tickManager.ApplyTickToEnemy(damage);
        }
    }

    public void GiveHand()
    {
        RemoveCards(CardSpawn.transform);
        for (int i = 0; i < amountCardsSpawn; i++)
        {
            CardCreator._instance.SpawnCardList();
        }
    }

    public void RemoveCards(Transform cardSpawn)
    {
        var children = new List<GameObject>();
        foreach (Transform child in cardSpawn)
        {
            children.Add(gameObject);
        }
        if (children.Count > 0)
        {
            foreach (Transform child in cardSpawn)
            {
                Destroy(child.gameObject);
            }
        }
    }

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
        }
        _instance = this;
    }
}
