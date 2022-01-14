using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager _instance;
    public GameObject CardSpawn, CardDeckBlocker, winScreen, LoseScreen, FightScene, ShopScene;
    public int forEnemyTickDamage, amountCardsSpawn;
    public ParticleSystem attackPrticles;
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

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Alpha1)){
            AnimationController._instance.PlayParticleList(AnimationController._instance.PowerUpAttackBelle);
        }
        if(Input.GetKeyDown(KeyCode.Alpha2)){
            AnimationController._instance.PlayParticleList(AnimationController._instance.ShieldParticleBelle);
        }
        if(Input.GetKeyDown(KeyCode.Alpha3)){
            AnimationController._instance.PlayParticleList(AnimationController._instance.UtilityParticleBelle);
        }
        if(Input.GetKeyDown(KeyCode.Alpha4)){
            AnimationController._instance.PlayParticleList(AnimationController._instance.FireDamageBelle);
        }
        if(Input.GetKeyDown(KeyCode.M)){
            myFSM.SetCurrentState(typeof(GridMapState));
            print("Command go to GridMap");
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
        Player._player.transform.GetChild(0).GetComponent<Animator>().SetTrigger("BasicAttack");
        if (damage >= EnemyBody._instanceEnemyBody.Shield)
        {
            int var;
            int kaartDamage = damage;
            var = kaartDamage -= EnemyBody._instanceEnemyBody.Shield;
            EnemyBody._instanceEnemyBody.Shield = 0;
            EnemyBody._instanceEnemyBody.Health -= var;
            EnemyBody._instanceEnemyBody.lastDamageDealtTo = var;
            //Debug.Log("Damage dealt to enemy: " + var);
        }
        else if (damage < EnemyBody._instanceEnemyBody.Shield)
        {
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

    public IEnumerator TimedUIUpdate(int damage){
        yield return new WaitForSeconds(0.25f);
        //Use to sync enemy UI update with the players basic attack animation
    }

    public IEnumerator TimedFireDamage(){
        yield return new WaitForSeconds(0.5f);
        AnimationController._instance.PlayParticleList(AnimationController._instance.FireDamageBelle);
    }

    IEnumerator ShowHit(){
        yield return new WaitForSeconds(0.4f);
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
