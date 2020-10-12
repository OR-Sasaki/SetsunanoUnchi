using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    [SerializeField] private List<GameObject> dontDestroyGameObjects;

    public enum Phase
    {
        Logo,
        Home,
        Game,
    }

    private PlayerProfile _playerProfile = new PlayerProfile();
    public PlayerProfile PlayerProfile
    {
        get => _playerProfile?.ShallowCopy();
        set => _playerProfile = value;
    }
    
    private GameStateBase<Phase> _currentGameState = null;

    protected override void Awake()
    {
        base.Awake();
        dontDestroyGameObjects.ForEach(DontDestroyOnLoad);
    }

    public void Start()
    {
        _playerProfile.name = "じぶん";
        _playerProfile.userId = (ulong) Random.Range(1000, 9999);
        
        GoToLogo();
    }

    public void OnUIEvent(UIBase ui, string message)
    {
        _currentGameState?.OnUIEvent(ui, message);
    }

    public void ChangeStatus<T>() where T : GameStateBase<Phase>
    {
        if(_currentGameState == null)
            Destroy(_currentGameState);
        else
            _currentGameState.OnStateClose();

        _currentGameState = this.gameObject.AddComponent<T>();
    }

    public void GoToLogo()
    {
        SceneManager.LoadScene("Logo");
        ChangeStatus<GameStateLogo>();
    }
    
    public void GoToHome()
    {
        SceneManager.LoadScene("Home");
        ChangeStatus<GameStateHome>();
    }
    
    public void GoToBattle(Battle.Regulation regulation)
    {
        SceneManager.LoadScene("Battle");
        ChangeStatus<GameStateBattle>();
    }
}

