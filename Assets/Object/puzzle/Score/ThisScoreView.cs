using UniRx;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Cysharp.Threading.Tasks;

public class ThisScoreView : MonoBehaviour
{
    [SerializeField]    private TextMeshProUGUI thisScore;
    private int score=0;

        void Start() {
        ScoreManager.I.ThisScore
        .Subscribe(async newScore => {
            ScoreAnimation<int> scoreAnimation  = new ScoreAnimation<int>(thisScore);
            score = await scoreAnimation.AnimateScore(score, newScore, 0.3f);
        })
        .AddTo(this);
    }
}
