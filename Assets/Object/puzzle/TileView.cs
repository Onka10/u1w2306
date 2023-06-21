using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class TileView : MonoBehaviour
{
    // [SerializeField] Image image2;
    // [SerializeField] Tile tile;
    [SerializeField] public int id;

        private void Start()
        {
            StartCoroutine(ExecuteDelayedLog());
        }

        private System.Collections.IEnumerator ExecuteDelayedLog()
        {
            yield return new WaitForSeconds(2);

            // TileManager.I.GetTile(id).isIn
            // .Subscribe(IN => ColorChange(IN))
            // .AddTo(this);

            // Debug.Log("初期化完了");

            TileManager.I.OnLoadTile
            .Subscribe(_ =>    Initsub())
            .AddTo(this);

            Initsub();
        }





        // private void Start()
        // {
        //     StartCoroutine(ExecuteDelayedLog());
        //     // Debug.Log("初期化完了");
        // }

        // private System.Collections.IEnumerator ExecuteDelayedLog()
        // {
        //     yield return new WaitForSeconds(1);

        //     TileManager.I.OnLoadTile
        //     .Subscribe(_ =>{
        //         Init();
        //         Debug.Log("初期化完了");
        //     } )
        //     .AddTo(this);
        // }

        private void Initsub()
        {
            TileManager.I.GetTile(id).isIn
            .Subscribe(IN => ColorChange(IN))
            .AddTo(this);
        }

        void ColorChange(bool IN){
            Tile t = TileManager.I.GetTile(id);
            if(IN)    this.gameObject.GetComponent<Image>().color = t.piece.Value.GetColor();
            else           this.gameObject.GetComponent<Image>().color = Color.white;
        }
}
