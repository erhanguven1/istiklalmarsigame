using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class ConnectGame : MonoBehaviourPunCallbacks
{

    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinRandomOrCreateRoom();
    }

    public override void OnJoinedRoom()
    {
        var pos = PhotonNetwork.IsMasterClient ? Vector3.left * 2 : Vector3.right * 2;
        PhotonNetwork.Instantiate("Player", pos, Quaternion.identity);
    }
}
