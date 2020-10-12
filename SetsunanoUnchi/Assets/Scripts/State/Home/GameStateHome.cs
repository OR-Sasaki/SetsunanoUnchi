using System;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class GameStateHome : GameStateBase<GameManager.Phase>
{
    public enum Phase
    {
        WaitFade,
        Idle,
        WaitMatching,
        SetUpCustomMatch,
        Setting,
    }

    private ReactiveProperty<Phase> _currentPhase = null;

    void Start()
    {
        _currentPhase = new ReactiveProperty<Phase>();
        _currentPhase.Value = Phase.WaitFade;
        _currentPhase.Subscribe(OnPhaseChanged);

        SceneFader.I.FadeOut(() => _currentPhase.Value = Phase.Idle);
    }

    void Update()
    {
        switch (_currentPhase.Value)
        {
            case Phase.WaitFade:
                break;
            case Phase.Idle:
                break;
            case Phase.WaitMatching:
                break;
            case Phase.SetUpCustomMatch:
                break;
            case Phase.Setting:
                break;
        }
    }

    public override void OnUIEvent(UIBase ui, string message)
    {
        switch (message)
        {
            case "GoRandomMatch":
                break;
            case "GoCustomMatch":
                break;
            case "GoLocalMatch":
                var playerProfiles = new Dictionary<string, PlayerProfile>();
                var playerInfos = new Dictionary<string, PlayerInfo>();

                // 自分
                var myselfPlayerProfile = GameManager.I.PlayerProfile;
                var myUid = myselfPlayerProfile.userId.ToString();
                playerProfiles.Add(myUid, myselfPlayerProfile);
                playerInfos.Add(myUid, new PlayerInfo() {isBot = false});

                // BOT
                for (int i = 0; i < Battle.MaxPlayerNum; i++)
                {
                    var playerProfile = new PlayerProfile()
                    {
                        userId = (ulong) i,
                        name = Player.SampleNames.GetRandom(),
                    };
                    var playerInfo = new PlayerInfo()
                    {
                        isBot = true,
                    };
                    playerProfiles.Add(i.ToString(), playerProfile);
                    playerInfos.Add(i.ToString(), playerInfo);
                }
                
                // バトルルール
                var regulation = new Battle.Regulation()
                {
                    isOnline = false,
                    myUid = myUid,
                    playerProfiles = playerProfiles,
                    playerInfos = playerInfos,
                };
                
                GoToBattle(regulation);

                break;
            case "Setting":
                break;
            default:
                Debug.LogError($"想定外のUIEventです。:{message}", ui);
                break;
        }
    }

    void GoToBattle(Battle.Regulation regulation)
    {
        SceneFader.I.FadeIn(() => { GameManager.I.GoToBattle(regulation); });
    }
    
    void OnPhaseChanged(Phase phase)
    {
        switch (phase)
        {
            case Phase.WaitFade:
                break;
            case Phase.Idle:
                break;
            case Phase.WaitMatching:
                break;
            case Phase.SetUpCustomMatch:
                break;
            case Phase.Setting:
                break;
        }
    }
}