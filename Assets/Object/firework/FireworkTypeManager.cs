using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireworkTypeManager : Singleton<FireworkTypeManager>
{
    public bool[,] test;

    private void Start() {
        // test = new bool[,]
        // {
        //     { false, false, false, false, false },
        //     { false, true, false, true, false },
        //     { false, false, true, false, false },
        //     { false, true, false, true, false },
        //     { false, false, false, false, false },
        // };

        test = new bool[,]
        {
            { false, false, true, false, false },
            { false, false, true, false, false },
            { false, false, true, false, false },
            { false, false, true, false, false },
            { false, false, true, false, false },
        };
    }

    public bool[,] getTest(){
        return test;
    }
}
