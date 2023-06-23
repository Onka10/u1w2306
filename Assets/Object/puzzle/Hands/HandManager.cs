using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEditor;

public class HandManager : Singleton<HandManager>
{
        //購読される変数
        public IReactiveCollection<Piece> Hand => _hand;
        private readonly ReactiveCollection<Piece> _hand = new ReactiveCollection<Piece>{};

        int now;
        Piece selectedPiece;


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

        public void Remove(){
            _hand.RemoveAt(now);
            now = -1;
            selectedPiece = null;
        }

        public void ReLoad(){
            _hand.Add(new Piece(ColorsRandom.GetRandomColor5()));
        }

        public void GetHandPiece(int i){
            now = i;
            selectedPiece = _hand[i];
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
