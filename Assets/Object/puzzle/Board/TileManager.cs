using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public class TileManager : Singleton<TileManager>
{
    public IObservable<Unit> OnLoadTile => loadTile;
    private readonly Subject<Unit> loadTile = new Subject<Unit>();

    readonly int size = 5;
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
        return new BoardCheck(BM).CountFilledTiles() * 10;
    }

    public FireworkData GetData(){
        BoardCheck BC = new(BM);
        
        return new FireworkData(BC.GetMostUsedColor(),150*Chain(),BC.GetFilledTileRatio());
    
        int Chain(){
            for(int i=1;i<6;i++){
                if(!BC.HasChain(i)){
                    return i-1;
                } 
            }

            return 1;
        }
    }
}
