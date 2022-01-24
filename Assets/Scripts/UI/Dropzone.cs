using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Feels Plugin Stuff
using MoreMountains.Feedbacks;
using MoreMountains.FeedbacksForThirdParty;
using MoreMountains.Tools;


public class Dropzone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    //public MMFeedbacks cardFeedbacks;
    
    public Color myColor;

    public void Start()
    {
        //cardFeedbacks = GetComponent<MMFeedbacks>();
    }
    public void OnPointerEnter(PointerEventData eventData) {
        //cardFeedbacks.PlayFeedbacks();
        //gameObject.GetComponent<Image>().color = myColor;
    }

    public void OnPointerExit(PointerEventData eventData) {
        //cardFeedbacks.StopFeedbacks();
        //gameObject.GetComponent<Image>().color = new Color(255,255,255,100);
    }

    public void OnDrop(PointerEventData eventData)
    {
        Draggable DroppedCardDragComponent = eventData.pointerDrag.GetComponent<Draggable>();
        CardTemplate DroppedCard = eventData.pointerDrag.GetComponent<CardTemplate>();
       //print(DroppedCard.card.Name + "Was dropped");

        if (DroppedCard == null) { return; }
        if (DroppedCard.card.Mana > Player._player.Mana) { return; }

        DroppedCardDragComponent.parentToReturnTo = this.transform;
        CommidCardAction(DroppedCard, DroppedCardDragComponent);
    }

    public void CommidCardAction(CardTemplate _droppedCard, Draggable _carDragComponent)
    {
        _droppedCard.ExecuteAction();
//        print(_droppedCard.card.Name + "Commited action");
        CardSystemManager._instance._MoveCardsToDiscard(_droppedCard.transform);
    }
}
