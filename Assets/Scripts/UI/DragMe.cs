using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragMe : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Transform parentToReturnTo = null;
    //public Transform cardDeckTransform;
    //public GameObject LeftSide, RightSide;


    public void OnBeginDrag(PointerEventData eventData)
    {
        parentToReturnTo = this.transform.parent;
        this.transform.SetParent(this.transform.parent.parent);
        GetComponent<CanvasGroup>().blocksRaycasts = false;
        GetComponent<RectTransform>().transform.rotation = Quaternion.Euler(0f,0f,0f); 
        //XXXXXX._instanceXXX.CheckKids();
    }

    public void OnDrag(PointerEventData eventData)
    {
        this.transform.position = eventData.position;
        GetComponent<RectTransform>().transform.rotation = Quaternion.Euler(0f,0f,0f); 
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //XXXXXX._instanceXXX.CheckKids();
        this.transform.SetParent(parentToReturnTo);
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        GetComponent<RectTransform>().transform.rotation = Quaternion.Euler(0f,0f,5f); 

        //Need two pos, start and end, if mousePos is somewhere inbetween than teh card should be the child of that
        //Begin kaart einde kaart, wat zijn de positions?

        // if(_instanceXXX.localMousePosition <= 300f){



        // }
    }
}
