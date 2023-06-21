using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class PhaseManager : Singleton<PhaseManager>
{
    // public static int MaxTownCount=4;
    public IReadOnlyReactiveProperty<GamePhase> Phase => _state;
    private readonly ReactiveProperty<GamePhase> _state = new ReactiveProperty<GamePhase>(global::GamePhase.Intro);

    public IReadOnlyReactiveProperty<InGamePhase> InPhase => _instate;
    private readonly ReactiveProperty<InGamePhase> _instate = new ReactiveProperty<InGamePhase>(global::InGamePhase.Blend);

}

public enum GamePhase{
    Intro,
    Title,
    InGame,
    Result
}

public enum InGamePhase{
    Blend,
    Show
}
