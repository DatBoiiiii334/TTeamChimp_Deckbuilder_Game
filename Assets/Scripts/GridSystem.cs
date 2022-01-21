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

    private void Start() {
        CheckForSelection(currentSelected);
    }

    public void CheckForSelection(GridPoint currentPoint)
    {
        if (currentPoint.WasSelected == false)
        {
            if (currentSelected != currentPoint)
            {
                currentSelected.WasSelected = true;
                currentSelected = currentPoint;
                currentPoint.IsSelected = true;
                currentPoint.FibeCheck();
            }
            return;
        }
        return;
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
