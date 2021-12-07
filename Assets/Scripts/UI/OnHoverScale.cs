using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class OnHoverScale : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Vector3 newSize = new Vector3(1.5f, 1.5f, 0f);
    private Vector3 oldSize = new Vector3(1f, 1f, 5f);

    //FOR WHEN INCREAING HIGHT AND WIDTH
    //private Vector3 newSize = new Vector2(420f, 560f);
    //private Vector3 oldSize = new Vector2(300f, 400f);

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (eventData.pointerCurrentRaycast.gameObject != null)
        {
            gameObject.transform.localScale = newSize;
            //gameObject.transform.position = new Vector3(0f,200f,0f);
            //gameObject.GetComponent<RectTransform>().sizeDelta = newSize;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        gameObject.transform.localScale = oldSize;
        //gameObject.transform.position = new Vector3(0f,0f,0f);
        //gameObject.GetComponent<RectTransform>().sizeDelta = oldSize;
    }
}
