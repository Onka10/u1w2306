using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public class MasterInput :Singleton<MasterInput>
{
    public IObservable<Unit> OnSpace => _space;
    private readonly Subject<Unit> _space = new Subject<Unit>();

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("space");
            _space.OnNext(Unit.Default);
        }

    }
}
