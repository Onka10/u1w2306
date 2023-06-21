using UnityEngine;

public class Piece
{
    Color color;

    public Piece(Color c){
        color = c; 
    }

    public Color GetColor(){
        return color;
    }
}
