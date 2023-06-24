using UnityEngine;
using TMPro;
using DG.Tweening;

public class TextBlinkAnimation : MonoBehaviour
{
    public float blinkDuration = 0.5f; // 点滅の周期（秒）
    public float blinkIntensity = 0.5f; // 点滅の明るさ（0〜1）

    private TextMeshProUGUI textMesh;
    private Tweener blinkTweener;

    private void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
        StartBlinkAnimation();
    }

    private void StartBlinkAnimation()
    {
        blinkTweener = textMesh.DOFade(blinkIntensity, blinkDuration).SetLoops(-1, LoopType.Yoyo);
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
