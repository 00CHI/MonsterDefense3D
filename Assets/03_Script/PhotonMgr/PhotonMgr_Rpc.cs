using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Photon.Pun;
using Photon.Realtime;

public partial class PhotonMgr_Rpc : MonoBehaviourPunCallbacks
{
    [PunRPC]
    void LobbyRoomEntry(bool _Owner)
    {

    }

    [PunRPC]
    void LobbyRoomReady(bool _Ready)
    {

    }
}
