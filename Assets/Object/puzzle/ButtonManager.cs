using UnityEngine;
using Cysharp.Threading.Tasks;
using System;

public class ButtonManager : Singleton<ButtonManager>
{
    private void Start() {
        // GameObjectが破棄された時にキャンセルを飛ばすトークンを作成
        // var token = this.GetCancellationTokenOnDestroy();
    }


    //i番目のハンドを選択した
    public void SelectHandPiece(int i){
        HandManager.I.SelectHandPiece(i);
    }

    //マスに入れた
    public void TileClick(int id){
        if(HandManager.I.GetSelectedPiece(out var p)){
            //設置
            if(!TileManager.I.SetPieceInTile(id,p)) return;
            //音鳴らす
            SEManager.I.PieceSet();
            //ピースを消費
            HandManager.I.SetHandPiece();
        }
    }

    public void Fire(){
        ExecuteGameEffects().Forget();
    }

    private async UniTask ExecuteGameEffects()
    {
        //前半
        //UIを消す
        PhaseManager.I.MoveHide();
        PhaseManager.I.InAnime();

        //今回の合成結果を受け取る
        FireworkData FD = TileManager.I.GetData();
        //打ち上げの処理を発生
        LaunchManager.I.Fire(FD);

        //スコア計算
        await UniTask.Delay(TimeSpan.FromSeconds(1));
        ScoreManager.I.AddTotalScore();
        await UniTask.Delay(TimeSpan.FromSeconds(1));

        //UI初期化
        TileManager.I.ResetTile();
        //UIをもどす
        PhaseManager.I.MoveHide();
        PhaseManager.I.InAnime();
    }
}