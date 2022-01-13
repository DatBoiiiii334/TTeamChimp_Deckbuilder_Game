using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Transform parentToReturnTo = null;
    public Transform cardDeckTransform;
    public Card.cardType _CardType;
    public bool applyToPlayer;
    private CardTemplate myCardTemplate;
    public int TempMana;

    //public FMODUnity.AudioManager AM;

    public void Start()
    {
        myCardTemplate = GetComponent<CardTemplate>();
        //_CardType = myCardTemplate._card;
        cardDeckTransform = this.transform.parent;
        //AudioManager._instance.TriggerCardHoverSounds();
    }

    public void OnPointerEnter(PointerEventData eventData) { 
        FMODUnity.AudioManager._instance.TriggerSoundEffect(FMODUnity.AudioManager._instance.CardHover);
    }

    public void OnPointerExit(PointerEventData eventData) {
        //gameObject.GetComponent<Image>().color = new Color(255,255,255,100);
     }


    public void OnBeginDrag(PointerEventData eventData)
    {
        FMODUnity.AudioManager._instance.TriggerSoundEffect(FMODUnity.AudioManager._instance.CardClickAndDrag);
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
