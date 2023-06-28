using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class ScoreManager : Singleton<ScoreManager>
{
    public IReadOnlyReactiveProperty<int> TotalScore => _totalScore;
    private readonly ReactiveProperty<int> _totalScore = new ReactiveProperty<int>(0);

    public IReadOnlyReactiveProperty<int> ThisScore => _thisScore;
    private readonly ReactiveProperty<int> _thisScore = new ReactiveProperty<int>(0);

    public void AddTotalScoreFromThis(){
        // int score = _thisScore.Value;//個数のスコア
        // score += TileManager.I.GetTaskScore();

        // _totalScore.Value += score;
        // _thisScore.Value = 0;

        _totalScore.Value += TileManager.I.GetThisScoreONBoard();
    }

    public void AddTotalScoreFromBack(){
        _totalScore.Value += 10;
    }
}
