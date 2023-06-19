using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kaributtonT : MonoBehaviour
{
    public void Click(int i){
        Piece p = PieceManager.I.GetSelectedPiece();
        TileManager.I.SetPieceInTile(i,p);
        Debug.Log("ピースをセット");
    }
}
