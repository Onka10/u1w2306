using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public class TileManager : Singleton<TileManager>
{
    public IObservable<Unit> OnLoadTile => loadTile;
    private readonly Subject<Unit> loadTile = new Subject<Unit>();

    public IReadOnlyReactiveProperty<int> OnPieceCount => _onPieceCount;
    private readonly ReactiveProperty<int> _onPieceCount = new ReactiveProperty<int>(0);

    readonly int size = 5;
    BoardModel BM;

    private void Start() {
        ResetTile();
        loadTile.OnNext(Unit.Default);
    }

    public bool SetPieceInTile(int id, Piece p){
        int row = BoardUtility<Tile>.ConvertIdToCoordinate(id,size).x;
        int col = BoardUtility<Tile>.ConvertIdToCoordinate(id,size).y;
        if(BM.PlacePiece(row,col,p)){
            _onPieceCount.Value = new BoardCheck(BM).CountFilledTiles();
            return true;
        }else{
            return false;
        }
    }

    public Tile GetTile(int id){
        int row = BoardUtility<Tile>.ConvertIdToCoordinate(id,size).x;
        int col = BoardUtility<Tile>.ConvertIdToCoordinate(id,size).y;
        return BM.GetTile(row,col);
    }

    public void ResetTile(){
        BM = new BoardModel(size);
        _onPieceCount.Value = 0;
        loadTile.OnNext(Unit.Default);
    }

    //ボード上のスコアを計算して返す
    public int GetThisScoreONBoard(){
        return new BoardCheck(BM).CountFilledTiles() * 10;
    }

    public FireworkData GetData(){
        BoardCheck BC = new(BM);

        Color color = BC.MixColorsByFrequency();
        int part = 150*Chain();
        float scale = MathUtils.MapPercentageToValue(BC.GetFilledTileRatio(),0.35f,0.7f);

        return new FireworkData(FireworkType.Normal,color,part,scale);
        
    
        int Chain(){
            for(int i=2;i<6;i++){
                if(!BC.HasChain(i)){
                    return i-1;
                } 
            }

            return 1;
        }
    }

    public void hoge(){
        BoardInspector BI = new(BM);
        // BI.InspectTiles3();
        BoardCheck BC = new(BM);
        Debug.Log(BC.AreAllTilesSameColor(FireworkTypeManager.I.getTest())); 
    }
}
