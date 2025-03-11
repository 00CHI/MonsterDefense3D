using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Photon.Pun;
using Photon.Realtime;

public partial class PhotonMgr : MonoBehaviourPunCallbacks
{
    public void CreateLobbyRoom(string _strRoom = null)
    {
        if(null == _strRoom)
        {
            return;
        }
        PhotonNetwork.CreateRoom(_strRoom);
    }

    public void RandomLobbyRoom()
    {
        PhotonNetwork.JoinRandomRoom();

    }

    public void joinLobbyRoom(string _strroom = null)
    {
        if (null == _strroom)
            return;
        PhotonNetwork.JoinRoom(_strroom);
    }

    public void LeaveRoom(bool _Com = true)
    {
        PhotonNetwork.LeaveRoom(_Com);
    }

    public void ScretLobbyRoom(string _strRoom, byte _Scrert, byte _MaxPlayer )
    {
        if(null == _strRoom)
            return;

        bool Open = _Scrert > 0 ? false : true;

        RoomOptions roomoptions = new RoomOptions() { IsVisible = Open}; // Player = _MaxPlayer}

        if (null == roomoptions)
            return;

        PhotonNetwork.JoinOrCreateRoom(_strRoom, roomoptions, null);

    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        foreach(RoomInfo room in roomList)
        {
        }
    }

    public override void OnJoinRoomFailed(short returnCode, string message) 
    {
        base.OnJoinRoomFailed(returnCode, message);
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        base.OnJoinRandomFailed(returnCode, message);
    }

    public void SendRoomEntry()
    {
        PV.RPC("LobbyRoomEntry", RpcTarget.All, true);
    }
    public void SendRoomReady()
    {
        PV.RPC("SendRoomReady", RpcTarget.Others, true);
    }
    public void SendStartInGame()
    {
        PV.RPC("StartInGame", RpcTarget.All);
    }
}
