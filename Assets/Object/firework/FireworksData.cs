using UnityEngine;

public struct FireworkData
{
    public Color fireColor;
    public int maxParticles;
    public float scale;
    public FireworkType FWtype;

    public FireworkData(FireworkType type, Color color,int part,float s){
        FWtype = type;
        fireColor = color;
        maxParticles = part;
        scale = s;
    }

}
