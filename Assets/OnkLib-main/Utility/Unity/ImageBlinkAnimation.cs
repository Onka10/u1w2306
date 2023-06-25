using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ImageBlinkAnimation : MonoBehaviour
{
    public float blinkDuration = 0.5f; // 点滅の周期（秒）
    public float blinkIntensity = 0.5f; // 点滅の明るさ（0〜1）

    private Image image;
    private Tweener blinkTweener;

    private void Start()
    {
        image = GetComponent<Image>();
        StartBlinkAnimation();
    }

    public void StartBlinkAnimation()
    {
        blinkTweener = image.DOFade(blinkIntensity, blinkDuration).SetLoops(-1, LoopType.Yoyo);
    }

    public void StopBlinkAnimation()
    {
        blinkTweener.Kill(); // アニメーション停止時にTweenを破棄
    }

    private void OnDestroy()
    {
        StopBlinkAnimation();
    }
}
