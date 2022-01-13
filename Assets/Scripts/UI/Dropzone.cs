using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Dropzone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Color myColor;
    public void OnPointerEnter(PointerEventData eventData) { 
        //gameObject.GetComponent<Image>().color = myColor;
    }

    public void OnPointerExit(PointerEventData eventData) {
        //gameObject.GetComponent<Image>().color = new Color(255,255,255,100);
    }

    public void OnDrop(PointerEventData eventData)
    {
        Draggable DroppedCardDragComponent = eventData.pointerDrag.GetComponent<Draggable>();
        CardTemplate DroppedCard = eventData.pointerDrag.GetComponent<CardTemplate>();

        if (DroppedCard == null) { return; }
        if (DroppedCard.card.Mana > Player._player.Mana) { return; }

        DroppedCardDragComponent.parentToReturnTo = this.transform;
        CommidCardAction(DroppedCard, DroppedCardDragComponent);
    }

    public void CommidCardAction(CardTemplate _droppedCard, Draggable _carDragComponent)
    {
        _droppedCard.ExecuteAction();

        CardSystemManager._instance._MoveCardsToDiscard(_droppedCard.transform);
    }
}
