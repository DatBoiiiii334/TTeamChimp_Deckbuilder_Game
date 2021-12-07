using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GridMapState: State{

    public override void Enter()
    {
        print("GridMapState");
        //Instantiate GridMap assets 
    }

    public override void Exit()
    {
        //Destroy GridMap assets
    }

}
