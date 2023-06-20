using UniRx;
using UnityEngine;

public class Tile
{
    // public bool isIn;

    public IReadOnlyReactiveProperty<bool> isIn => _isIn;
    private readonly ReactiveProperty<bool> _isIn = new ReactiveProperty<bool>();


    // public Piece piece;
    public IReadOnlyReactiveProperty<Piece> piece => _piece;
    private readonly ReactiveProperty<Piece> _piece = new ReactiveProperty<Piece>();

    public Tile(){
        _isIn.Value = false;
    }

    public void SetPiece(Piece p){
        _piece.Value = p;
        _isIn.Value = true;
    }
}
