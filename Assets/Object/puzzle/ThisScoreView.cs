using UniRx;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ThisScoreView : MonoBehaviour
{
    [SerializeField]    private TextMeshProUGUI thisScore;

    void Start() {
        ScoreManager.I.ThisScore
        .Subscribe(s => thisScore.text = s.ToString())
        .AddTo(this);
    }
}
