using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerEventField : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler 
{
    public delegate void CardActionOnPlayer();
    public static event CardActionOnPlayer OnCardActionPlayer;

    public void OnPointerEnter(PointerEventData eventData)
    {}

    public void OnPointerExit(PointerEventData eventData)
    {}

    public void OnDrop(PointerEventData eventData)
    {
        OnCardActionPlayer?.Invoke();
    }
}
