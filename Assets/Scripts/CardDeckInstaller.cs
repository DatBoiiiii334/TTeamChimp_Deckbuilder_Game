using UnityEngine;
using UnityEngine.EventSystems;

public class CardDeckInstaller : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData eventData){
        CheckDistanceBetweenChilds();

    }

    public void OnPointerExit(PointerEventData eventData){

    }

    public void CheckDistanceBetweenChilds(){
        /*
            1. look at mouse position relative to UI
            2. Check if mouse pos is between 2 child positions
            3. if so the card his position is now updated
        */ 
    }

    public void Update(){
        // print(Input.mousePosition);
        // if(Input.mousePosition ){

        // }
    }

    public void OnDrop(PointerEventData eventData){
        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();

        if(d != null){
            d.parentToReturnTo = this.transform;
        }
    }
}
