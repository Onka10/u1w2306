using UnityEngine;

public struct FireworkData
{
    public Color fireColor;
    public int maxParticles;
    public float scale;

    public FireworkData(Color color,int part,float s){
        fireColor = color;
        maxParticles = part;
        scale = s;
    }

}
