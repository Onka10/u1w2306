using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FWSetManager : Singleton<FWSetManager>
{
    public FireworksSet fireworkPrefab;
    public List<FireworksSet> prefabs;

    public FireWork GetFireworkPrefabs(FireworkType FT){
        for(int i=0;i<prefabs.Count;i++){
            if(prefabs[i].type == FT) return prefabs[i].prefab;
        }

        return fireworkPrefab.prefab;
    }
}
