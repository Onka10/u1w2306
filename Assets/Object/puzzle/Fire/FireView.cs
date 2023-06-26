using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class FireView : MonoBehaviour
{
    private void Start()
    {
        //ボタン操作
        this.GetComponent<Button>().OnClickAsObservable()
        .Where(_ => TileManager.I.OnPieceCount.Value > 0)
        .Subscribe(_=> ButtonManager.I.Fire())
        .AddTo(this);

        TileManager.I.OnPieceCount
        .Subscribe(pc=> ColorChange(pc))
        .AddTo(this);
    }


    void ColorChange(int pc){
        Image[] images = GetComponentsInChildren<Image>(true);

        bool firable=false;
        if(pc > 0) firable=true;

        Color mycolor = Color.black;

        if(firable) mycolor=Color.yellow;
        else      mycolor=Color.gray;

        foreach (Image image in images)
        {
            // ここにイメージの処理を追加
            // 例えば、image.color = Color.red; のような処理を行う
            image.color = mycolor;
        }
    }
}
