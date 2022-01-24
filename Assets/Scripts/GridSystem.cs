using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridSystem : MonoBehaviour
{
    public static GridSystem _instance;
    public GridPoint[] myGridPoints;

    [Header("Button Colors")]
    public Color InActiveColor;
    public Color ActiveColor;
    public Color HighLightColor;
    public Color NormalColor;
    public GridPoint currentSelected;

    [Header("Line Distance")]
    public float lineDistance;

    public void SetCurrentTile(GridPoint myTile){
        if(myTile != currentSelected){
            print("Became the one");
            currentSelected.ColorGridPoint(GridSystem._instance.InActiveColor);
            currentSelected.myButton.interactable = false;
            currentSelected = myTile;
        }else{
            print("Already the one");
            currentSelected.ColorGridPoint(GridSystem._instance.ActiveColor);
        }
    }

    public void CheckDistace(GridPoint myTile, GridPoint NextTile){
        Vector3 thisPos = myTile.transform.position;
        Vector3 newPos = NextTile.transform.position;

        if(thisPos.x <= newPos.x){
            if(thisPos.y <= newPos.y){
                print("GreenLight");
                return;
            }
        }
        print("red light");        
    }

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(_instance);
        }
        else
        {
            _instance = this;
        }
    }
}
