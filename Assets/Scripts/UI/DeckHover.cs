using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DeckHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public Animator CardDeckAnim;


    public void OnPointerEnter(PointerEventData eventData){
        CardDeckAnim.SetBool("OnHover", true);
        //CardDeckAnim.SetTrigger("Hover");
    }

    public void OnPointerExit(PointerEventData eventData){
        //CardDeckAnim.SetTrigger("NoHover");
        CardDeckAnim.SetBool("OnHover", false);
    }
}

