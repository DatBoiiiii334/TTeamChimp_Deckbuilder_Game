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

    public void SetCurrentTile(GridPoint myTile)
    {
        if (myTile != currentSelected)
        {
            if (myTile.GetComponent<Button>().interactable == true)
            {
                print("Became the one");
                currentSelected.ColorGridPoint(GridSystem._instance.InActiveColor);
                currentSelected.GetComponent<Button>().interactable = false;
                // currentSelected.GetComponent<Button>().enabled = false;
                // currentSelected.GetComponent<Image>().color = Color.black;
                currentSelected = myTile;
                TypeClick(currentSelected.enemyEncounter);
            }
        }
        else
        {
            print("Already the one");
        }
    }

    public void TypeClick(int Encounter){
        switch(Encounter){
            case 0:
                //  Red ridinghood 
                    GridMapState._instance.PickEnemyEncounter(1);
            break;

            case 1:
                //  Gnomes
                    GridMapState._instance.PickEnemyEncounter(0);
            break;

            case 2:
                //  Poos in boots (mini boss )
            break;

            case 3:
                //  Shop
                GridMapState._instance.GoToStore();
            break;
            
            case 4:
                //  End Boss
            break;
        }
    }

    public void CheckDistace(GridPoint myTile, GridPoint NextTile)
    {
        Vector3 thisPos = myTile.transform.position;
        Vector3 newPos = NextTile.transform.position;

        if (thisPos.x <= newPos.x)
        {
            if (thisPos.x + lineDistance >= newPos.x)
            {
                // if(thisPos.x - newPos.x <= lineDistance){
                print("GreenLight " + thisPos.x + " " + newPos.x);

                return;
            }
            print("no reach");
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
