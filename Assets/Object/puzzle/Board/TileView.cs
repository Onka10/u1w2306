
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class TileView : MonoBehaviour
{
    [SerializeField] public int id;

    private void Start()
    {
        //ボタン操作
        this.GetComponent<Button>().OnClickAsObservable()
        .Subscribe(_=>ButtonManager.I.TileClick(id))
        .AddTo(this);

        //タイルの中の変更
        InitSub();

        //ボードの更新
        TileManager.I.OnLoadTile
        .Subscribe(_ =>InitSub())
        .AddTo(this);
    }

    //ボードの中身の購読
    private void InitSub()
    {
        TileManager.I.GetTile(id).IsIn
        .Subscribe(IN => ColorChange(IN))
        .AddTo(this);
    }

    void ColorChange(bool IN){
        Tile t = TileManager.I.GetTile(id);
        if(IN)    this.gameObject.GetComponent<Image>().color = t.piece.Value.GetColor();
        else      this.gameObject.GetComponent<Image>().color = Color.white;
    }
}
