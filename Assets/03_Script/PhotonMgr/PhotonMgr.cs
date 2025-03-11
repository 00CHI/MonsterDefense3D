using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Photon.Pun;
using Photon.Realtime;

public partial class PhotonMgr : MonoBehaviourPunCallbacks
{
    public PhotonView PV;

    private void Awake()
    {

        PhotonNetwork.GameVersion = "1.0.0";//게임 버전이 맞아야 함께할 수 있도록
        PhotonNetwork.SendRate = 20;
        PhotonNetwork.SerializationRate = 10;

        DontDestroyOnLoad(this);

        PhotonNetwork.ConnectUsingSettings();//포톤 서버에 접속하는 함수
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        base.OnDisconnected(cause);
    }

    public override void OnConnectedToMaster()//가장 처음 들어온 사람이 방장이 됨.
    {
        base.OnConnectedToMaster();

        PhotonNetwork.JoinLobby();// 로비에 다 모이게 해줌.

        Debug.Log("OnConnectedToMaster");
    }

    public override void OnJoinedLobby()//로비라는 공간에 정상적으로 보내지면 호출됨 <> 호출되지 않으면 Disconnect
    {
        base.OnJoinedLobby();
        Debug.Log("OnJoinedLobby");

    }
    //여기까지 접속과정.

    public void OnLobby()
    {
        PhotonNetwork.IsMessageQueueRunning = true; //Queue를 통해 메세지를 띄우겠다.
    }

    public void LeaveLobby(bool _Com = true)
    {
        PhotonNetwork.LeaveLobby();
    }
}
