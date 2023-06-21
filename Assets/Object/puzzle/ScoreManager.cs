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

    public void ReLoadThisScore(){
        _thisScore.Value = TileManager.I.GetThisScoreONBoard();
    }

    public void AddThisScore2TotalScore(){
        _totalScore.Value += _thisScore.Value;
        _thisScore.Value = 0;
    }
}
