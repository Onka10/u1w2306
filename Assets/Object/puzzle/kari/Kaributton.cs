using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//UI Presenter
public class Kaributton : MonoBehaviour
{
    //i番目のハンドを選択した
    public void SelectHandPiece(int i){
        Piece p = HandManager.I.GetHandPiece(i);
        PieceManager.I.SelectPiece(p);
        // Debug.Log("ピースを選択、赤");
    }

    //i版のマスに入れた
    public void TileClick(TileView view){
        if(PieceManager.I.GetSelectedPiece(out var p)){

            if(!TileManager.I.SetPieceInTile(view.id,p)) return;
            HandManager.I.Remove();
            PieceManager.I.RemovePiece();

            //次のをリロード
            HandManager.I.ReLoad();
        }
    }

    public void Fire(){
        //打ち上げの処理を発生
        //UIを消す

        //UI初期化
        TileManager.I.ResetTile();
    }
}
