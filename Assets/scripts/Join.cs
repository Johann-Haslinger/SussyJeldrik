using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Join : MonoBehaviourPunCallbacks
{

    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        PhotonNetwork.JoinRoom(PlayerPrefs.GetString("Code"));
    }


    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Game");
    }
}
