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
        ColorGridPoint(GridSystem._instance.HighLightColor); // nyan
        GridSystem._instance.CheckDistace(GridSystem._instance.currentSelected, gameObject.GetComponent<GridPoint>());
    }

    public void OnPointerExit(PointerEventData eventData)//ON exiting Hover
    {
        ColorGridPoint(GridSystem._instance.NormalColor); //green
    }

    public void OnPointerClick(PointerEventData eventData)//ON clicking button
    {
        ColorGridPoint(GridSystem._instance.ActiveColor); // gold
        GridSystem._instance.SetCurrentTile(gameObject.GetComponent<GridPoint>());
    }


    public void ColorGridPoint(Color myColor)
    {
        ColorBlock colorBlock = gameObject.GetComponent<Button>().colors;
        colorBlock.normalColor = myColor;
        gameObject.GetComponent<Button>().colors = colorBlock;
    }



    public void RemoveSprite()
    {
        myImage.sprite = null;
    }

    
}