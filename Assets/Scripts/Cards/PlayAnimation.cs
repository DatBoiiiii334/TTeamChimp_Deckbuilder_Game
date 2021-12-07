using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimation : MonoBehaviour
{
    public void PlayPlayerAnimation(string whatToDo, float duration){
        //StartCoroutine(StartPlayerAnimation(whatToDo, duration));
        Player._player.anim.SetTrigger(whatToDo);
        //Player._player.anim.ResetTrigger(whatToDo);
    }

    // public IEnumerator StartPlayerAnimation(string whatToDo, float duration)
    // {
    //     print("Playing: " + whatToDo + " - duration " + duration);
    //     //Player._player.anim.SetBool(whatToDo, true);
    //     Player._player.anim.SetTrigger(whatToDo);
    //     yield return new WaitForSeconds(0.1f);
    //     //Player._player.anim.SetBool(whatToDo, false);
    //     StopAllCoroutines();
    // }
}
