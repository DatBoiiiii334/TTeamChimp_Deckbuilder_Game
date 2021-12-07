using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EventManager : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    public delegate void CardAction();
    public static event CardAction OnCardAction;

    public void OnPointerEnter(PointerEventData eventData)
    {
        //Debug.Log("OnPointerEnter");
        //OnCardAction?.Invoke();
        //OnCardAction?.Invoke();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //Debug.Log("OnPointerExit");
        //OnCardAction?.Invoke();
        
    }

    public void OnDrop(PointerEventData eventData)
    {
        //Debug.Log(eventData.pointerDrag.name + "was dropped on " + gameObject.name);
        //Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
        DragMe d = eventData.pointerDrag.GetComponent<DragMe>();
        d.parentToReturnTo = this.transform;
        OnCardAction?.Invoke();
        //print("Dopped");
    }
}
