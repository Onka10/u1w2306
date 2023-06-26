using UnityEngine;

public class CustomHoverBehavior : HoverDetector
{
    // UIごとに異なる動作を設定するメソッド
    protected override void StartHover()
    {
        base.StartHover();

        // UIごとの処理を追加
    }

    // UIごとに異なる動作を停止するメソッド
    protected override void StopHover()
    {
        base.StopHover();

        // UIごとの停止処理を追加
    }
}
