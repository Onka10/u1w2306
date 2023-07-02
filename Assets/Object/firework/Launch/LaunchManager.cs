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
    List<FireworkData> fireworkDataBase;

    public IObservable<Unit> G => _allKill;
    private readonly Subject<Unit> _allKill = new Subject<Unit>();



    public float minDelay = 1f;  // ランダムな待機時間の最小値
    public float maxDelay = 5f;  // ランダムな待機時間の最大値

    private void Start()
    {
        fireworkDataBase = new List<FireworkData>();
        StartBackFireScheduler().Forget();
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
    }

    void BackFire(FireworkData fireworkData,FireWork prefab)
    {
        launchers[0].LaunchFirework(fireworkData, prefab);
        SEManager.I.Fire();
        ScoreManager.I.AddTotalScoreFromBack();
    }

    private async UniTask StartBackFireScheduler()
    {
        while (true)
        {
            // ランダムな秒数を待機
            float delay = UnityEngine.Random.Range(minDelay, maxDelay);
            await UniTask.Delay((int)(delay * 1000));

            // fireworkDataBaseが空でない場合にBackFireを呼び出す
            if (fireworkDataBase.Count > 0)
            {
                int index = UnityEngine.Random.Range(0,fireworkDataBase.Count);
                BackFire(fireworkDataBase[index],FWSetManager.I.GetFireworkPrefabs(fireworkDataBase[index].FWtype));
            }
        }
    }
}