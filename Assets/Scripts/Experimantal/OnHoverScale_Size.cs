using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class OnHoverScale_Size : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Vector3 newSize = new Vector3(420f, 560f, 5f);
    private Vector3 oldSize = new Vector3(300f, 400f, 0f);


    public void OnPointerEnter(PointerEventData eventData)
    {
        if (eventData.pointerCurrentRaycast.gameObject != null)
        {
            print("On pointer");
            gameObject.GetComponent<RectTransform>().sizeDelta = newSize;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        gameObject.GetComponent<RectTransform>().sizeDelta = oldSize;
    }
}
