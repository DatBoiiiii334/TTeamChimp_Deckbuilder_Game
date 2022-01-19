using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public static AnimationController _instance;
    public List<ParticleSystem> PowerUpAttackBelle; 
    public List<ParticleSystem> ShieldParticleBelle; 
    public List<ParticleSystem> UtilityParticleBelle; 
    public List<ParticleSystem> FireDamageBelle; 

    [Header("Dev Delays")]
    public float delaySound, delayAnim;

    //________PLAYER ANIMATIONS_________________________________________________________________________________________
    public void PlayerBasicAttackAnim(){
        CheckForAnim(Player._player.transform.GetChild(0));
        Player._player.transform.GetChild(0).GetComponent<Animator>().SetTrigger("BasicAttack");
    }

    public void PlayerHitAnim(){
        CheckForAnim(Player._player.transform.GetChild(0));
        Player._player.transform.GetChild(0).GetComponent<Animator>().SetTrigger("Hit");
    }

    //________ENEMY ANIMATIONS_________________________________________________________________________________________
    public void EnemyBasicAttackAnim(){
        CheckForAnim(EnemyBody._instanceEnemyBody.transform.GetChild(0));
        EnemyBody._instanceEnemyBody.transform.GetChild(0).GetComponent<Animator>().SetTrigger("BasicAttack");
    }

    public void EnemyHitAnim(){
        CheckForAnim(EnemyBody._instanceEnemyBody.transform.GetChild(0));
        EnemyBody._instanceEnemyBody.transform.GetChild(0).GetComponent<Animator>().SetTrigger("Hit");
    }

    //________UTILITY METHODS_________________________________________________________________________________________
    private void CheckForAnim(Transform transform){
        if(transform.GetComponent<Transform>() == null){
            Debug.LogError(transform.gameObject.name + " Does not have an animator!");
            return;
        }
    }

    public void PlayParticleList(List<ParticleSystem> _particleSystem){
        foreach(ParticleSystem effect in _particleSystem){
            effect.Play();
        }
    }

    public IEnumerator playWithDelay(float _delaySound, float _delayAnim, List<ParticleSystem> _particleSystem, FMODUnity.EventReference soundEffect){
        print("play with delay");
        yield return new WaitForSeconds(delaySound);
        FMODUnity.AudioManager._instance.TriggerSoundEffect(soundEffect);
        yield return new WaitForSeconds(delayAnim);
        PlayParticleList(_particleSystem);
        print("play with delay particle system");
    }

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
        }
    }
}
