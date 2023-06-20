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

        //隣接しないと置けない
        if(! BM.CanPlacePiece(BM.GetCoordinatesFromId(id).row,BM.GetCoordinatesFromId(id).col,p)) return false;

        BM.PlacePiece(BM.GetCoordinatesFromId(id).row,BM.GetCoordinatesFromId(id).col,p);
        return true;
        // tiles[i].SetPiece(p);
    }

    public Tile GetTile(int id){
        return BM.GetTile(BM.GetCoordinatesFromId(id).row,BM.GetCoordinatesFromId(id).col);
        // return tiles[id];
    }

    public void ResetTile(){
        BM = new BoardManager(5);
        BM.PrintBoard();

        // for(int i=0 ;i<tiles.Length;i++){
        //     tiles[i] = new Tile();
        // }

        loadTile.OnNext(Unit.Default);
    }
}
