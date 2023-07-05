using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using UniRx;
using System;

public class LaunchManager : Singleton<LaunchManager>
{
    // public FireWork fireworkPrefab;
    // public List<FireWork> prefabs;
    public FrontLauncher frontLauncher;
    public List<BackLauncher> launchers;
    public List<FireworkData> fireworkDataBase;

    public IObservable<Unit> G => _allKill;
    private readonly Subject<Unit> _allKill = new Subject<Unit>();

    private readonly ReactiveProperty<int> count = new ReactiveProperty<int>(0);

    private void Start()
    {
        fireworkDataBase = new List<FireworkData>();

        //初手で走るが、ライブラリが0だから打ち上げた後に走る
        count
        .Subscribe(_ => BackFire())
        .AddTo(this);
    }

    //背景を起動
    void BackFire(){
        if(fireworkDataBase.Count <= 0) return;
        launchers[count.Value -1 ].StartBackFireScheduler().Forget();
    }

    public void Fire(FireworkData fireworkData,FireWork prefab)
    {
        frontLauncher.LaunchFirework(fireworkData, prefab);
        SEManager.I.Fire();
        _allKill.OnNext(Unit.Default);
    }

    //ライブラリ追加のタイミングをずらす
    public void AddBase(FireworkData fireworkData){
        fireworkDataBase.Add(fireworkData);
        if(count.Value >= 5) return;
        count.Value = fireworkDataBase.Count /5 +1;
        
    }
}
