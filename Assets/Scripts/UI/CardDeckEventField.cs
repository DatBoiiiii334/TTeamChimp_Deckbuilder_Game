using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardDeckEventField : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    public delegate void CardActionOnCardDeck();
    public static event CardActionOnCardDeck OnCardActionOnCardDeck;

    public void OnPointerEnter(PointerEventData eventData)
    {}

    public void OnPointerExit(PointerEventData eventData)
    {}

    public void OnDrop(PointerEventData eventData)
    {
        OnCardActionOnCardDeck?.Invoke();
    }
}
