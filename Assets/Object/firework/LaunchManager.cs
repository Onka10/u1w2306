using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchManager : Singleton<LaunchManager>
{
    public FireWork fireworks;

    public void Fire(FireworkData FD){
        fireworks.SetParentParticleProperties(FD.fireColor,FD.maxParticles,FD.scale);
        fireworks.SetAllChildParticleProperties(FD.fireColor,FD.maxParticles);
    }

}
