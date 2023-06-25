using System.Collections.Generic;
using UnityEngine;

public class LaunchManager : Singleton<LaunchManager>
{
    public FireWork fireworkPrefab;
    public FrontLauncher frontLauncher;
    public List<BackLauncher> launchers;
    List<FireworkData> fireworksData;

    private void Start()
    {
        fireworksData = new List<FireworkData>();
    }

    public void Fire(FireworkData fireworkData)
    {
        frontLauncher.LaunchFirework(fireworkData, fireworkPrefab);
        fireworksData.Add(fireworkData);

        BackFire(fireworkData);
    }

    void BackFire(FireworkData fireworkData)
    {
        launchers[0].LaunchFirework(fireworkData, fireworkPrefab);
    }
}
