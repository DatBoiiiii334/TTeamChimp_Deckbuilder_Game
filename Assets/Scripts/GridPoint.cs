using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GridPoint : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    [Header("Button Components")]
    public Image myImage;
    //public enum enemyEncounter{RedRidingHood, Gnomes, PussInBoots, Shop, TheBeast};
    public int enemyEncounter;

    private void Start() {

        if(GridSystem._instance.currentSelected == gameObject.GetComponent<GridPoint>()){
            ColorGridPoint(GridSystem._instance.ActiveColor);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)//ON entering Hover
    {
        if(GridSystem._instance.currentSelected == gameObject.GetComponent<GridPoint>()){
            ColorGridPoint(GridSystem._instance.ActiveColor); // gold
            GridSystem._instance.CheckDistace(GridSystem._instance.currentSelected, gameObject.GetComponent<GridPoint>());
        }
        ColorGridPoint(GridSystem._instance.HighLightColor); // nyan
    }

    public void OnPointerExit(PointerEventData eventData)//ON exiting Hover
    {
        if(GridSystem._instance.currentSelected == gameObject.GetComponent<GridPoint>()){
            ColorGridPoint(GridSystem._instance.ActiveColor); // gold
        }else if(gameObject.GetComponent<Button>().interactable == false){
            ColorGridPoint(GridSystem._instance.InActiveColor); // green
        }else{
            ColorGridPoint(GridSystem._instance.NormalColor); // green
        }
        
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