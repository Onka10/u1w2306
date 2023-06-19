using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceManager : Singleton<PieceManager>
{
    public Piece selectedPiece;

    public void SelectPiece(Piece p){
        selectedPiece = p;
    }

    public Piece GetSelectedPiece(){
        return selectedPiece;
    }
}
