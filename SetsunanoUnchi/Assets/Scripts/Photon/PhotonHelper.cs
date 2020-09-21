using System.Collections;
using System.Runtime.Remoting.Messaging;
using UnityEngine;
using UnityEngine.Events;

public class PhotonHelper : SingletonPunMonoBehaviour<PhotonHelper>
{
    private const string GameVersion = "ver0.0.1";
    public static bool IsJoinedLobby { get; private set; }
    public static bool IsJoinedRoom { get; private set; }

    public UnityAction OnJoinedLobbyAction;
    public UnityAction OnJoinedRoomAction;
    public UnityAction OnJoiedRoomOtherPlayerAction;

    void Start()
    {
        PhotonNetwork.ConnectUsingSettings(GameVersion);
    }

#region Override

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        IsJoinedLobby = true;

        OnJoinedLobbyAction?.Invoke();
    }

    public override void OnJoinedRoom()
    {
        IsJoinedRoom = true;
        
        photonView.RPC("OnJoinedPlayerNotification", PhotonTargets.Others);
        OnJoinedRoomAction?.Invoke();
    }
    
#endregion

    public void JoinOrCreateRandomRoom()
    {
        var roomOptions = new RoomOptions();
        roomOptions.isVisible = true;
        roomOptions.MaxPlayers = 4;

        var currentTime = UnixTimeUtil.GetCurrentUnixTime();

        string roomName = $"{currentTime}-${Random.Range(0, 100000)}";

        PhotonNetwork.JoinOrCreateRoom(roomName, roomOptions, TypedLobby.Default);
    }

    public int GetRoomMemberNum()
    {
        return PhotonNetwork.room.PlayerCount;
    }

    public void LeaveRoom()
    {
        if (!IsJoinedRoom)
            return;

        IsJoinedRoom = false;
        PhotonNetwork.LeaveRoom();
    }

    public static IEnumerator WaitJoinLobby(UnityAction onJoinLobbyAction = null)
    {
        while (!IsJoinedLobby)
        {
            yield return null;
        }

        onJoinLobbyAction?.Invoke();
    }

    [PunRPC]
    void OnJoinedPlayerNotification()
    {
        OnJoiedRoomOtherPlayerAction?.Invoke();
    }
}