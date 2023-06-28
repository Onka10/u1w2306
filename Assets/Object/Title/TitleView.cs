using UnityEngine;
using UnityEngine.UI;
using UniRx;


public class TitleView : MonoBehaviour
{
    [SerializeField] Button StartButton;
    [SerializeField] Image  startImage;
    [SerializeField] Button CreditButton;
    [SerializeField] GameObject CreditObject;

    void Start()
    {
        StartButton.OnClickAsObservable()
        .Where(_ => ! PhaseManager.I.IsMoved.Value)
        .Subscribe(_ =>{
            SEManager.I.Fire();
            PhaseManager.I.Play();
        })
        .AddTo(this);  

        BlinkAnimation<Image> blinkAnimation = new BlinkAnimation<Image>(startImage);
        // 点滅アニメーションを開始（周期: 0.5秒、明るさ: 0.5）
        blinkAnimation.StartBlinkAnimation(1.5f, 0.3f);


        CreditButton.OnClickAsObservable()
        .Subscribe(_ => CreditObject.SetActive(true))
        .AddTo(this);
    }
}