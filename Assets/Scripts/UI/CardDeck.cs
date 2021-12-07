using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardDeck : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    //public Draggable.cardType _CardType = Draggable.cardType.DAMAGE;
    //public Card.cardType _CardType;

    public void OnPointerEnter(PointerEventData eventData){
        //Debug.Log("OnPointerEnter");
    }

    public void OnPointerExit(PointerEventData eventData){
        //Debug.Log("OnPointerExit");
    }

    public void OnDrop(PointerEventData eventData){
        //Debug.Log(eventData.pointerDrag.name + "was dropped on " + gameObject.name);

        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
        //DragMe = eventData.pointerDrag.GetComponent<DragMe>();
        //Card d = GetComponent<Card>();

        if(d != null){
            d.parentToReturnTo = this.transform;
        }
    }
}
