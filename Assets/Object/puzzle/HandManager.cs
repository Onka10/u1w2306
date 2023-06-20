using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEditor;

public class HandManager : Singleton<HandManager>
{
        //購読される変数
        public IReactiveCollection<Piece> Hand => _hand;

        //private
        private readonly ReactiveCollection<Piece> _hand = new ReactiveCollection<Piece>{};

        int now;


        private void Start() {
            InitHand();
        }


        public void InitHand()
        {
            _hand.Clear(); // 一度手札をクリアする

            _hand.Add(new Piece(ColorsRandom.GetRandomColor5()));
            _hand.Add(new Piece(ColorsRandom.GetRandomColor5()));
            _hand.Add(new Piece(ColorsRandom.GetRandomColor5()));
        }

        public Piece Remove(){
            Piece p = _hand[now];
            _hand.RemoveAt(now);
            now = -1;
            return p;
        }

        public void ReLoad(){
            _hand.Add(new Piece(ColorsRandom.GetRandomColor5()));
        }

        public Piece GetHandPiece(int i){
            now = i;
            return _hand[i];
        }

    
}
