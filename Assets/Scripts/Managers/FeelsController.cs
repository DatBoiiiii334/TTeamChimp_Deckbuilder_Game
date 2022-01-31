using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using MoreMountains.Feedbacks;
using MoreMountains.FeedbacksForThirdParty;
using MoreMountains.Tools;

public class FeelsController : MonoBehaviour
{
    public MMFeedbacks Attack;
    public MMFeedbacks magicAttacked;
    public MMFeedbacks Attacked;
    public MMFeedbacks Heal;
    public MMFeedbacks Shield;
    // public static FeelsController _instance;
    // public MMFeedbacks[] BelleFeels;
    // public MMFeedbacks[] RedRidingHoodFeels;
    // public MMFeedbacks[] GnomesFeels;
    //Feel free to add more lists for other chars
    // public int value;

    // private void Update() {
    //     if(Input.GetKeyDown(KeyCode.Alpha0)){
    //         //TriggerFeelItem(Attack);
    //     }
    // }
    
    public void TriggerFeelItem(MMFeedbacks _anim){
        _anim.PlayFeedbacks();
    }

    // public void TriggerFeelItem(MMFeedbacks[] _list, int number){
    //     _list[number].PlayFeedbacks();
    // }

    // public void TriggerFeelMulti(MMFeedbacks[] _list1, int number1, MMFeedbacks[] _list2, int number2){
    //     _list1[number1].PlayFeedbacks();
    //     _list2[number2].PlayFeedbacks();
    // }

    // private void Awake() {
    //     if(_instance != null){
    //         Destroy(gameObject);
    //     }else{
    //         _instance = this;
    //     }
    // }
}
