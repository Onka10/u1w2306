using UniRx;
using UnityEngine;

public class Tile
{
    public bool isIn;
    // public Piece piece;
    public IReadOnlyReactiveProperty<Piece> piece => _piece;
    private readonly ReactiveProperty<Piece> _piece = new ReactiveProperty<Piece>();

    public Tile(){
        isIn = false;
    }

    public void SetPiece(Piece p){
        _piece.Value = p;
        isIn = true;
        Debug.Log("pi-suが代わりました"+_piece.Value.color);
    }
}
