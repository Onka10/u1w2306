using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class BlinkAnimation<T> where T : Graphic
{
    private T target;
    private Tweener blinkTweener;

    /// <summary>
    /// BlinkAnimation クラスのコンストラクタ
    /// </summary>
    /// <param name="target">点滅させる対象の Graphic コンポーネント</param>
    public BlinkAnimation(T target)
    {
        this.target = target;
    }

    /// <summary>
    /// 点滅アニメーションを開始します。
    /// </summary>
    /// <param name="blinkDuration">点滅の周期（秒）</param>
    /// <param name="blinkIntensity">点滅の明るさ（0～1）</param>
    public void StartBlinkAnimation(float blinkDuration, float blinkIntensity)
    {
        blinkTweener = target.DOFade(blinkIntensity, blinkDuration).SetLoops(-1, LoopType.Yoyo);
    }

    /// <summary>
    /// 点滅アニメーションを停止します。
    /// </summary>
    public void StopBlinkAnimation()
    {
        blinkTweener.Kill(); // アニメーション停止時にTweenを破棄
    }
}


//使用例
    // private void Start()
    // {
    //     Image image = GetComponent<Image>();
    //     blinkAnimation = new BlinkAnimation<Image>(image);

    //     // 点滅アニメーションを開始（周期: 0.5秒、明るさ: 0.5）
    //     blinkAnimation.StartBlinkAnimation(0.5f, 0.5f);
    // }

    // private void OnDestroy()
    // {
    //     blinkAnimation.StopBlinkAnimation();
    // }