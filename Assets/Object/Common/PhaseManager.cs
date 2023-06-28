using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using DG.Tweening;

public class PhaseManager : Singleton<PhaseManager>
{
    public IReadOnlyReactiveProperty<GamePhase> Phase => _state;
    private readonly ReactiveProperty<GamePhase> _state = new ReactiveProperty<GamePhase>(global::GamePhase.Title);

    public IReadOnlyReactiveProperty<InGamePhase> InPhase => _instate;
    private readonly ReactiveProperty<InGamePhase> _instate = new ReactiveProperty<InGamePhase>(global::InGamePhase.Blend);

    public IReadOnlyReactiveProperty<bool> IsMoved => _move;
    private readonly ReactiveProperty<bool> _move = new ReactiveProperty<bool>();

    public IReadOnlyReactiveProperty<bool> IsAnimating => _isAnimating;
    private readonly ReactiveProperty<bool> _isAnimating = new ReactiveProperty<bool>();

    [SerializeField] GameObject tran;

    public void Play(){
        _state.Value = GamePhase.Road;
        StartCoroutine(WaitOneSecond());
    }

    private IEnumerator WaitOneSecond()
    {
        TweenFloat(0,1,1);
        yield return new WaitForSeconds(1f);
        TweenFloat(1,0,1);
        yield return new WaitForSeconds(1f);
        _state.Value = GamePhase.InGame;
    }

    public void MoveHide(){
        _move.Value  = _move.Value ? false : true;
    }

    public void InAnime(){
        _isAnimating.Value  = _isAnimating.Value ? false : true;
    }


    void TweenFloat(float minValue, float maxValue, float duration)
    {
        // 値を変更する対象のオブジェクトやコンポーネントを取得
        // ここでは例として自身のRendererを使用しますが、適宜変更してください
        Renderer renderer = tran.GetComponent<Renderer>();

        // DOTweenのTweenメソッドを使用して値の変更を定義
        // 最小値から最大値までの範囲で変化するよう設定し、指定の秒数かけて変更します
        DOTween.To(() => minValue, value => {
            renderer.material.SetFloat("_transition_pow", value);
        }, maxValue, duration);
    }

}


public enum GamePhase{
    Title,
    InGame,
    Result,
    Road
}

public enum InGamePhase{
    Blend,
    Show
}
