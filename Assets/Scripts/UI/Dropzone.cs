using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class Dropzone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData eventData) { }

    public void OnPointerExit(PointerEventData eventData) { }

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
