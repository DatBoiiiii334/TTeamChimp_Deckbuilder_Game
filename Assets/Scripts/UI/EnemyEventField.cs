using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EnemyEventField : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{ 
    public delegate void CardActionOnEnemy();
    public static event CardActionOnEnemy OnCardActionEnemy;

    public void OnPointerEnter(PointerEventData eventData)
    {}

    public void OnPointerExit(PointerEventData eventData)
    {}

    public void OnDrop(PointerEventData eventData)
    {
        OnCardActionEnemy?.Invoke();
    }
}
