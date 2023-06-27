using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireworksFactory : Singleton<FireworksFactory>
{
    public FireWork fireworkPrefab;
    public List<FireWork> prefabs;

    public FireWork GetFireworkPrefabs(FireworkType FT){
        return fireworkPrefab;
    }
}
