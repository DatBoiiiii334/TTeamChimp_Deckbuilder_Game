using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PointAble : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject TempDescription;

    public void OnPointerEnter(PointerEventData eventData){
        TempDescription.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData){
        TempDescription.SetActive(false);
    }
}
