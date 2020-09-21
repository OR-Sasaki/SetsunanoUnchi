using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    [SerializeField] private List<GameObject> dontDestroyGameObjects;
    private GameStateBase _currentGameState = null;
    
    protected override void Awake()
    {
        base.Awake();
        dontDestroyGameObjects.ForEach(DontDestroyOnLoad);
    }

    public void Start()
    {
        SceneFader.I.SetOnOff(false);
        SceneFader.I.FadeIn();
    }

    public void OnUIEvent(UIBase ui, string message)
    {
        _currentGameState?.OnUIEvent(ui, message);
    }
}

