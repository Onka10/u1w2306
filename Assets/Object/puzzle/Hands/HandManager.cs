using UniRx;
using System;
using UnityEngine;

public class HandManager : Singleton<HandManager>
{
    //購読される変数
    public IReactiveCollection<Piece> Hand => _hand;
    private readonly ReactiveCollection<Piece> _hand = new ReactiveCollection<Piece>{};

    public IReadOnlyReactiveProperty<int> Now => _now;
    private readonly ReactiveProperty<int> _now = new ReactiveProperty<int>();

    Piece selectedPiece;


    private void Start() {
        _hand.Clear(); // 一度手札をクリアする

        _hand.Add(new Piece(ColorsRandom.GetRandomColor3()));
        _hand.Add(new Piece(ColorsRandom.GetRandomColor3()));
        _hand.Add(new Piece(ColorsRandom.GetRandomColor3()));

        _now.Value = 0;

        _now.Subscribe(n => selectedPiece = _hand[n]).AddTo(this);
    }

    public void SetHandPiece(){
        int now = _now.Value; //nowの更新に必要
        _hand.RemoveAt(_now.Value);
        _hand.Add(new Piece(ColorsRandom.GetRandomColor3()));
        _now.SetValueAndForceNotify(now);
    }

    public void SelectHandPiece(int i){
        _now.Value = i;
    }

    public bool GetSelectedPiece(out Piece sp)
    {
        if (selectedPiece != null)
        {
            sp = selectedPiece;
            return true;
        }
        else
        {
            sp = null;
            return false;
        }
    }
}
