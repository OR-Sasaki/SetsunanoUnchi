using UniRx;
using UnityEngine;

public class GameStateLogo : GameStateBase<GameManager.Phase>
{
    public enum Phase
    {
        WaitFade,
        ShowLogo,
    }

    private ReactiveProperty<Phase> _currentPhase = null;

    void Start()
    {
        _currentPhase = new ReactiveProperty<Phase>();
        _currentPhase.Value = Phase.WaitFade;
        _currentPhase.Subscribe(OnPhaseChanged);

        SceneFader.I.SetOnOff(true);
        SceneFader.I.FadeOut(() => _currentPhase.Value = Phase.ShowLogo);
    }

    void Update()
    {
        switch (_currentPhase.Value)
        {
            case Phase.WaitFade:
                break;
            case Phase.ShowLogo:
                break;
        }
    }

    void OnPhaseChanged(Phase phase)
    {
        switch (phase)
        {
            case Phase.WaitFade:
                break;
            case Phase.ShowLogo:
                サウンドロゴを流す();
                SceneFader.I.FadeIn(GameManager.I.GoToHome);
                _currentPhase.Value = Phase.WaitFade;
                break;
        }
    }

    void サウンドロゴを流す()
    {
        // todo 実装
    }
}