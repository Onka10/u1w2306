using UniRx;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Cysharp.Threading.Tasks;

public class TotalScoreView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    
    private int score=0;

    void Start() {
        ScoreManager.I.TotalScore
        .Subscribe(async newScore => {
            ScoreAnimation<int> scoreAnimation  = new ScoreAnimation<int>(scoreText);
            score = await scoreAnimation.AnimateScore(score, newScore, 0.5f);
        })
        .AddTo(this);
    }
}