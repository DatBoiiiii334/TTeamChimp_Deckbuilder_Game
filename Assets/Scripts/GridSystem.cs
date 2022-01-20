using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridSystem : MonoBehaviour
{
    public static GridSystem _instance;
    public GridPoint[] myGridPoints;
    public Sprite playerSprite;

    [Header("Spawn Image")]
    public GameObject ImageIllustration;
    public Color newColor;

    [Header("ImageSize")]
    public Vector2 imageSize;

    private void Start() {
        foreach(GridPoint grid in myGridPoints){
            grid.GetComponent<GridPoint>().InActiveColor = newColor;
            
            //GameObject gridSprite = Instantiate(ImageIllustration, grid.transform);
            //gridSprite.transform.parent = grid.transform;
            //grid.transform.GetChild(0).GetComponent<Image>().rectTransform.sizeDelta = imageSize;

            //this code should:
            //  - Give each grid in the list the gridPoint script
            //  - Change the color of the inActiveColor to newColor
            //  - Create a child with an Image Component
            //  - Change the size of the image to imageSize
        }
    }

    public void updateGridPoints(){
        
    }

    public void CheckForCurrentGridPoint(GridPoint currentPoint){
        //GridPoint oldPoint;
        GridPoint newPoint = currentPoint;
        
    }

    private void Awake() {
        if(_instance != null){
            Destroy(_instance);
        }else{
            _instance = this;
        }
    }
}
