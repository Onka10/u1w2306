using UnityEngine;
using UnityEngine.UI;
using UniRx;
public class TitleView : MonoBehaviour
{
    [SerializeField] Button StartButton;
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

        CreditButton.OnClickAsObservable()
        .Subscribe(_ => CreditObject.SetActive(true))
        .AddTo(this);
    }
}
