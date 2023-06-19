using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kaributton : MonoBehaviour
{
    public void SetPieceR(){
        PieceManager.I.SelectPiece(new Piece(Color.red));
        Debug.Log("ピースを選択、赤");
    }

    public void SetPieceB(){
        PieceManager.I.SelectPiece(new Piece(Color.blue));
    }
}
