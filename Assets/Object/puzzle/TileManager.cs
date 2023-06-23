using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public class TileManager : Singleton<TileManager>
{
    public IObservable<Unit> OnLoadTile => loadTile;
    private readonly Subject<Unit> loadTile = new Subject<Unit>();

    int size = 5;
    BoardManager BM;
    BoardModel BM2;

    private void Start() {
        ResetTile();
    }

    public bool SetPieceInTile(int id, Piece p){
        //Set able判定
        // if(! BM.CanPlacePiece(id)) return false;

        // BM.PlacePiece(id,p);

        int row = BoardUtility<Tile>.ConvertIdToCoordinate(id,size).x;
        int col = BoardUtility<Tile>.ConvertIdToCoordinate(id,size).y;
        return BM2.PlacePiece(row,col,p);
    }

    public Tile GetTile(int id){
        // return BM.GetTile(id);
        int row = BoardUtility<Tile>.ConvertIdToCoordinate(id,size).x;
        int col = BoardUtility<Tile>.ConvertIdToCoordinate(id,size).y;
        return BM2.GetTile(row,col);
    }

    public void ResetTile(){
        // BM = new BoardManager();

        BM2 = new BoardModel(size);

        loadTile.OnNext(Unit.Default);
    }

    //ボード上のスコアを計算して返す
    public int GetThisScoreONBoard(){
        return BM2.GetPieceCount() * 10;
    }

    public int GEtTaskScore(){
        int score=0;
            // if(BM2.ExploreBoard().Count <= 3) score += 50;
             // if(BM2.HasChain(4)) score += 50;
        return score;
    }
}
