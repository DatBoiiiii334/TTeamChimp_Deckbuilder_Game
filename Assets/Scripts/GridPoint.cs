using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GridPoint : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler
{
    [Header("Button Components")]
    public Button myButton;
    public Image myImage;
    public BaseEventData m_BaseEvent;
    [Space]

    [Header("Button Addons")]
    public Color InActiveColor;
    public Color ActiveColor;
    public Sprite currentSprite;

    private bool wasSelected;

    public void Start()
    {
        myButton = this.GetComponent<Button>();
        //this.myImage.sprite = currentSprite;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {

        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //If allowed should light up
        //UsedGridPoint();
        // if (myButton.IsHighlighted(m_BaseEvent) == true)
        // {

        // }
        

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        UsedGridPoint();
        wasSelected = true;
        //Move char to grid
        // - Reverence the char with the gridsytem
    }

    public void UsedGridPoint()
    {
        ColorBlock cb = myButton.colors;
        cb.normalColor = InActiveColor;
        myButton.colors = cb;
    }

    public void RemoveSprite()
    {
        myImage.sprite = null;
    }

}

public class Example: Selectable{

    public void FibeCheck(Button myButton, Color myColor){
        ColorBlock cb = myButton.colors;
        cb.normalColor = myColor;
        
        if (IsHighlighted() == true){
            myButton.colors = cb;
        }
    }
}
