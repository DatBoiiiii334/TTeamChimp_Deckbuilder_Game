using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopState : State
{
    public override void Enter()
    {
        //GameManager._instance.TransitionScreenAnim.SetTrigger("StartTransition");
        StartCoroutine(SetupShop());
    }

    public override void Exit()
    {
        GameManager._instance.TransitionScreenAnim.SetTrigger("StartTransition");
        GameManager._instance.ShopAnim.SetBool("OpenShop", false);
        StartCoroutine(PackUpShop());
    }

    IEnumerator SetupShop(){
        yield return new WaitForSeconds(2f);
        GameManager._instance.FightScene.SetActive(false);
        GameManager._instance.ShopScene.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        GameManager._instance.ShopAnim.SetBool("OpenShop", true);
    }

    IEnumerator PackUpShop(){
        yield return new WaitForSeconds(2f);
        GameManager._instance.FightScene.SetActive(true);
        GameManager._instance.ShopScene.SetActive(false);
    }
}
