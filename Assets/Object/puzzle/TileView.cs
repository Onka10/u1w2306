using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class TileView : MonoBehaviour
{
    // [SerializeField] Image image2;
    // [SerializeField] Tile tile;
    [SerializeField] int id;

        private void Start()
        {
            StartCoroutine(ExecuteDelayedLog());
        }

        private System.Collections.IEnumerator ExecuteDelayedLog()
        {
            yield return new WaitForSeconds(2);

            TileManager.I.GetTile(id).piece
            .Skip(1)
            .Subscribe(_ => ColorChange())
            .AddTo(this);

            Debug.Log("初期化完了");
        }

        void ColorChange(){
            Debug.Log("呼び出し");
            Tile t = TileManager.I.GetTile(id);
            if(!t.isIn)    this.gameObject.GetComponent<Image>().color = t.piece.Value.color;
            // if(!t.isIn)    image2.color = t.piece.Value.color;


        }
}
