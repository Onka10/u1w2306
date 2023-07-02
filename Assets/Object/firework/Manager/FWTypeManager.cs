using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FWTypeManager : Singleton<FWTypeManager>
{
    public bool[,] star1;
    public bool[,] star2;
    public bool[,] bee1;
    public bool[,] bee2;

    private void Start() {
        star1 = new bool[,]
        {
            { false, false, false, false, false },
            { false, false, true, false, false },
            { false, true, true, true, false },
            { false, true, false, true, false },
            { false, false, false, false, false },
        };

        star2 = new bool[,]
        {
            { false, false, false, false, false },
            { false, false, true, false, false },
            { true, true, true, true, true },
            { false, true, false, true, false },
            { false, false, false, false, false },
        };

        bee1 = new bool[,]
        {
            { false, false, false, false, false },
            { false, true, false, true, false },
            { false, false, false, false, false },
            { false, true, false, true, false },
            { false, false, false, false, false },
        };

        bee2 = new bool[,]
        {
            { false, false, true, false, false },
            { false, false, true, false, false },
            { true, true, false, true, true },
            { false, false, true, true, false },
            { false, false, true, false, false },
        };
    }

    public bool[,] GetStar1(){
        return star1;
    }

    public bool[,] GetStar2(){
        return star2;
    }

    public bool[,] GetBee1(){
        return bee1;
    }

    public bool[,] GetBee2(){
        return bee1;
    }
}
