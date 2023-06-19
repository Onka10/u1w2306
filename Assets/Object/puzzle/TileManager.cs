using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : Singleton<TileManager>
{
    public Tile[] tiles = new Tile[13];

    private void Start() {
        for(int i=0 ;i<tiles.Length;i++){
            tiles[i] = new Tile();
        }
    }

    public void SetPieceInTile(int i, Piece p){
        tiles[i].SetPiece(p);
    }

    public Tile GetTile(int n){
        return tiles[n];
    }
}
