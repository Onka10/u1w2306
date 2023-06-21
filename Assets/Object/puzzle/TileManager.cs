using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public class TileManager : Singleton<TileManager>
{
    // [SerializeField] public Tile[] tiles = new Tile[13];

    public IObservable<Unit> OnLoadTile => loadTile;
    private readonly Subject<Unit> loadTile = new Subject<Unit>();

    BoardManager BM;

    private void Start() {
        ResetTile();
    }

    public bool SetPieceInTile(int id, Piece p){
        // Debug.Log("idを変換:"+BM.GetCoordinatesFromId(id));

        //置けない判定
        if(! BM.CanPlacePiece(id,p)) return false;

        BM.PlacePiece(id,p);
        Debug.Log(id+"設置");
        return true;
        // tiles[i].SetPiece(p);
    }

    public Tile GetTile(int id){
        return BM.GetTile(id);
        // return tiles[id];
    }

    public void ResetTile(){
        BM = new BoardManager(5);
        // BM.PrintBoard();

        // for(int i=0 ;i<tiles.Length;i++){
        //     tiles[i] = new Tile();
        // }

        loadTile.OnNext(Unit.Default);
    }

    //ボードマネージャーのスコアを計算して返す
    public int GetThisScoreONBoard(){
        int score=0;
        PieceCount PC = BM.CountPieces();

        //タスク1：色が3色以内
        if(PC.GetColorVariety() < 3) score += 50;
        return score;
    }
}
