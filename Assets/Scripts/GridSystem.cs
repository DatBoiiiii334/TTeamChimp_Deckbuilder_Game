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
    private GridPoint _currentSelected;

    [Header("Line Distance")]
    public float lineDistance;

    private void Start() {
        _currentSelected = currentSelected;
    }

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
            case 1:
                //  Red ridinghood 
                    GridMapState._instance.PickEnemyEncounter(1);
            break;

            case 2:
                //  Gnomes
                    GridMapState._instance.PickEnemyEncounter(0);
            break;

            case 3:
                //  Poos in boots (mini boss )
                GridMapState._instance.PickEnemyEncounter(2);
            break;

            case 4:
                //  Shop
                    GridMapState._instance.GoToStore();
            break;
            
            case 5:
                //  End Boss
                GridMapState._instance.PickEnemyEncounter(3);
            break;
        }
    }

    public void ResetGrid(){
        currentSelected = _currentSelected; // resets current selected gridpoint
        foreach(Transform _gridpoint in gameObject.transform){
            if(_gridpoint != currentSelected){
                _gridpoint.GetComponent<Button>().interactable = true;
                _gridpoint.transform.GetComponent<GridPoint>().ColorGridPoint(GridSystem._instance.NormalColor);
            }else if(_gridpoint.transform.GetComponent<GridPoint>() == currentSelected){
                _gridpoint.transform.GetComponent<GridPoint>().ColorGridPoint(GridSystem._instance.ActiveColor);
            }   
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
