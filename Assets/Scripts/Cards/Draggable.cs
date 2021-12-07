using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Transform parentToReturnTo = null;
    public Transform cardDeckTransform;
    public Card.cardType _CardType;
    public bool applyToPlayer;
    private CardTemplate myCardTemplate;
    public int TempMana;

    public void Start()
    {
        myCardTemplate = GetComponent<CardTemplate>();
        //_CardType = myCardTemplate._card;
        cardDeckTransform = this.transform.parent;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        parentToReturnTo = this.transform.parent;
        this.transform.SetParent(this.transform.parent.parent);
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        this.transform.position = eventData.position;
        gameObject.transform.localScale = new Vector3(1f,1f,5f);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        this.transform.SetParent(parentToReturnTo);
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        gameObject.transform.localScale = new Vector3(1f,1f,0f);
    }
}
