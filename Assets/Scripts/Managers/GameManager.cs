using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager _instance;
    public GameObject CardSpawn, CardDeckBlocker, winScreen, LoseScreen, FightScene, ShopScene;
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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            myFSM.SetCurrentState(typeof(ShopState));
        }

        if ( Input.GetKey(KeyCode.E) && Input.GetKeyDown(KeyCode.Alpha1))
        {
            print("Input enemy basicAttack");
            EnemyBody._instanceEnemyBody.transform.GetChild(0).GetComponent<Animator>().SetTrigger("BasicAttack");
        }
        if ( Input.GetKey(KeyCode.E) && Input.GetKeyDown(KeyCode.Alpha2))
        {
            print("Input enemy Heal");
            EnemyBody._instanceEnemyBody.transform.GetComponent<Animator>().SetTrigger("Heal");
        }
        if ( Input.GetKey(KeyCode.E) && Input.GetKeyDown(KeyCode.Alpha3))
        {
            print("Input enemy Heal");
            EnemyBody._instanceEnemyBody.transform.GetChild(0).GetComponent<Animator>().SetTrigger("Hit");
        }
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
        StartCoroutine(ShowHit());
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

    IEnumerator ShowHit(){
        yield return new WaitForSeconds(0.1f);
        EnemyBody._instanceEnemyBody.transform.GetChild(0).GetComponent<Animator>().SetTrigger("Hit");
    }

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
        }else{
            _instance = this;
        }
    }
}
