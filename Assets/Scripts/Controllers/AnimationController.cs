using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public static AnimationController _instance;

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
