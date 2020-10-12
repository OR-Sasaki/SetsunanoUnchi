using System.Collections.Generic;

public static class Battle // Define
{
    public const int MaxPlayerNum = 4;
    
    public class Regulation
    {
        public bool isOnline;
        public string myUid;
        public Dictionary<string, PlayerProfile> playerProfiles;
        public Dictionary<string, PlayerInfo> playerInfos;
    }
}