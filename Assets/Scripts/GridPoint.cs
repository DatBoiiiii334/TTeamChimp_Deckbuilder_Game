using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GridPoint : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    [Header("Button Components")]
    public Button myButton;
    public Image myImage;

    public bool IsSelected;
    public bool WasSelected;

    public void Start()
    {
        myButton = this.GetComponent<Button>();
    }

    public void OnPointerEnter(PointerEventData eventData)//ON entering Hover
    {
        FibeCheck();
        ColorGridPoint(GridSystem._instance.HighLightColor); // nyan
    }

    public void OnPointerExit(PointerEventData eventData)//ON exiting Hover
    {
        FibeCheck();
        ColorGridPoint(GridSystem._instance.NormalColor); //green
    }

    public void OnPointerClick(PointerEventData eventData)//ON clicking button
    {
        FibeCheck();
        ColorGridPoint(GridSystem._instance.ActiveColor); // gold
        IsSelected = true;
    }





    public void ColorGridPoint(Color myColor)
    {
        ColorBlock cb = myButton.colors;
        cb.normalColor = myColor;
        myButton.colors = cb;
    }

    public void FibeCheck(){
        if (IsSelected)
        {
            ColorGridPoint(GridSystem._instance.ActiveColor); //gold
            //myButton.interactable = !myButton.interactable;
            return;
        }

        if(WasSelected){
            ColorGridPoint(GridSystem._instance.InActiveColor); //grey
            //myButton.interactable = !myButton.interactable;
            return;
        }
    }

    public void RemoveSprite()
    {
        myImage.sprite = null;
    }

    
}