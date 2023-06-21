using UniRx;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TotalScoreView : MonoBehaviour
{
    [SerializeField]    private TextMeshProUGUI thisScore;

    void Start() {
        ScoreManager.I.TotalScore
        .Subscribe(s => thisScore.text = s.ToString())
        .AddTo(this);
    }
}
