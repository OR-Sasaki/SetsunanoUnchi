public class GameStateBattle : GameStateBase<GameManager.Phase>
{
    private Battle.Regulation _regulation;
    
    public void Init(Battle.Regulation regulation)
    {
        _regulation = regulation;

        ゲームのセットアップ();
        プレイヤーのセットアップ();
        BOTのセットアップ();
        UIのセットアップ();
    }

    void ゲームのセットアップ()
    {
        
    }

    void プレイヤーのセットアップ()
    {
        
    }

    void BOTのセットアップ()
    {
        
    }

    void UIのセットアップ()
    {
        // UI取得 + INIT
    }
}