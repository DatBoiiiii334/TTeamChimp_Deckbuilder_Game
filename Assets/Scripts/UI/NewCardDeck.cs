using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NewCardDeck : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{

    public void OnPointerEnter(PointerEventData eventData){
        //Debug.Log("OnPointerEnter");
    }

    public void OnPointerExit(PointerEventData eventData){
        //Debug.Log("OnPointerExit");
    }

    public void OnDrop(PointerEventData eventData){
        DragMe d = eventData.pointerDrag.GetComponent<DragMe>();
        //EventManager.
        //EventManager.CardAction.OnCardAction();
        d.parentToReturnTo = this.transform;
    }
}
