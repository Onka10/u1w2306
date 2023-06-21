using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceManager : Singleton<PieceManager>
{
    public Piece selectedPiece;

    public void SelectPiece(Piece p){
        selectedPiece = p;
    }

    public void RemovePiece(){
        selectedPiece = null;
    }

    public bool GetSelectedPiece(out Piece sp)
    {
        if (selectedPiece != null)
        {
            sp = selectedPiece;
            return true;
        }
        else
        {
            sp = null;
            return false;
        }
    }
}
