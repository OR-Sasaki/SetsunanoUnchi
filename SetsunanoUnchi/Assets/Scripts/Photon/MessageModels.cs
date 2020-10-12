public class PlayerProfile
{
    public ulong userId;
    public string name;

    public PlayerProfile ShallowCopy() => (PlayerProfile) this.MemberwiseClone(); 
}

public class PlayerInfo
{
    public bool isBot;
}