using UnityEngine;
using UnityEngine.EventSystems;

public class PointAble : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject TempDescription;

    public void OnPointerEnter(PointerEventData eventData){
        //TempDescription.SetActive(true);
        //Eneable to show description instead of main char art
    }

    public void OnPointerExit(PointerEventData eventData){
        //TempDescription.SetActive(false);
    }
}
