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
    BoardModel BM;

    private void Start() {
        ResetTile();
    }

    public bool SetPieceInTile(int id, Piece p){
        int row = BoardUtility<Tile>.ConvertIdToCoordinate(id,size).x;
        int col = BoardUtility<Tile>.ConvertIdToCoordinate(id,size).y;
        return BM.PlacePiece(row,col,p);
    }

    public Tile GetTile(int id){
        int row = BoardUtility<Tile>.ConvertIdToCoordinate(id,size).x;
        int col = BoardUtility<Tile>.ConvertIdToCoordinate(id,size).y;
        return BM.GetTile(row,col);
    }

    public void ResetTile(){
        BM = new BoardModel(size);
        loadTile.OnNext(Unit.Default);
    }

    //ボード上のスコアを計算して返す
    public int GetThisScoreONBoard(){
        return BM.GetPieceCount() * 10;
    }

    public int GetTaskScore(){
        int score=0;
            // if(BM2.ExploreBoard().Count <= 3) score += 50;
             // if(BM2.HasChain(4)) score += 50;
        return score;
    }
}
