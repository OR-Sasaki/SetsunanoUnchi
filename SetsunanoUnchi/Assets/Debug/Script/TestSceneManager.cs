using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon;
using UnityEngine.Events;
using UnityEngine.UI;
using MonoBehaviour = Photon.MonoBehaviour;

public class TestSceneManager : MonoBehaviour
{
   private const string GameVersion = "0.0.1";

   [SerializeField] private Text m_Text;

   void Start()
   {
      StartCoroutine(PhotonHelper.WaitJoinLobby(JoinRoom));
   }

   void JoinRoom()
   {
      PhotonHelper.I.JoinOrCreateRandomRoom();
   }

   private int count = 0;
   public void OnClickButton()
   {
      PhotonHelper.I.photonView.RPC("Message", PhotonTargets.All, count);
      count++;
   }

   [PunRPC]
   void Message(int count)
   {
      m_Text.text = $"m-{PhotonHelper.I.GetRoomMemberNum()} c-{count}";
   }
}
