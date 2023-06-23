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
    }

    //マスに入れた
    public void TileClick(TileView view){
        if(PieceManager.I.GetSelectedPiece(out var p)){
            //設置
            if(!TileManager.I.SetPieceInTile(view.id,p)) return;

            SEManager.I.PieceSet();

            HandManager.I.Remove();
            PieceManager.I.RemovePiece();

            //スコアプレビューを更新
            ScoreManager.I.ReLoadThisScore();

            //次のピースをリロード
            HandManager.I.ReLoad();
        }
    }

    public void Fire(){
        //スコア計算
        ScoreManager.I.AddThisScore2TotalScore();

        //打ち上げの処理を発生

        //SE
        SEManager.I.Fire();
        
        //UIを消す

        //UI初期化
        TileManager.I.ResetTile();
    }
}