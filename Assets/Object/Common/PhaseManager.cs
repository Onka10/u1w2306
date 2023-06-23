using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

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

    
    public void Play(){
        _state.Value = GamePhase.InGame;
    }

    public void MoveHide(){
        _move.Value  = _move.Value ? false : true;
    }

    public void InAnime(){
        _isAnimating.Value  = _isAnimating.Value ? false : true;
    }

}


public enum GamePhase{
    Title,
    InGame,
    Result
}

public enum InGamePhase{
    Blend,
    Show
}
