using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager _instance;
    public GameObject CardSpawn, CardDeckBlocker, FightScene, ShopScene;
    public int forEnemyTickDamage, amountCardsSpawn;
    public ParticleSystem attackPrticles;
    FSM myFSM;

    public Animator TransitionScreenAnim, ShopAnim, OpenBookAnim;

    [Header("Delay Amount for Volume")]
    public float delayValue;

    [Header("Icons")]
    public Sprite[] SpriteList; 

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

    // ____________________________ TESTING
    public IEnumerator Delay(List<ParticleSystem> myParticlelist, FMODUnity.EventReference SoundEffect){
        FMODUnity.AudioManager._instance.TriggerSoundEffect(SoundEffect);
        yield return new WaitForSeconds(delayValue);
        AnimationController._instance.PlayParticleList(myParticlelist);
    }
    //_______________________________________________________________________



    public void isEnemyDead()
    {
        if (EnemyBody._instanceEnemyBody.Health <= 0)
        {
            //winScreen.SetActive(true);
            myFSM.SetCurrentState(typeof(WinState));
            CardPicker.instance_CardPicker.OpenNewCardsWindow();
        }
    }

    public void DamageEnemy(int damage)
    {
        //StartCoroutine(ShowHit());
        //print("TAKE THAT TASTE THE PAIN");
        //Player._player.transform.GetChild(0).GetComponent<Animator>().SetTrigger("BasicAttack");
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
        yield return new WaitForSeconds(0.2f);
        FMODUnity.AudioManager._instance.TriggerSoundEffect(FMODUnity.AudioManager._instance.BelleAttacks);
        //FMODUnity.AudioManager._instance.TriggerSoundEffect(FMODUnity.AudioManager._instance.BasicAttacks);
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
