using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XXXXXX : MonoBehaviour
{
    // public static XXXXXX _instanceXXX;
    public float posX, posY, spacingX;


    // public void awake()
    // {
    //     if (_instanceXXX != null)
    //     {
    //         Destroy(gameObject);
    //     }
    //     _instanceXXX = this;
    // }

    private void Start() {
        CheckKids();
    }

    public void CheckKids()
    {
        
        int v;
        v = gameObject.transform.childCount;
        //if(gameObject.transform.childCount == 0){return;}
        foreach (Transform child in gameObject.transform)
        {
            //gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(320f * v, 500f);
            gameObject.GetComponent<HorizontalLayoutGroup>().spacing = -100f * v;
            // gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(posX * v, posY);
            // gameObject.GetComponent<HorizontalLayoutGroup>().spacing = spacingX * v;
        }
        //print(gameObject.name + " Child Amount: " +gameObject.transform.childCount);
        
        //localMousePosition = gameObject.GetComponent<RectTransform>().InverseTransformPoint(Input.mousePosition);
        //print(localMousePosition);
        // if (gameObject.GetComponent<RectTransform>().rect.Contains(localMousePosition))
        // {
        //     //if localMousePosition <= 300
        //     // print("It worky");

        // }
    }
}
