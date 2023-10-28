using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class CreateAndJoin : MonoBehaviourPunCallbacks
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
        PlayerPrefs.SetString("Code", GenerateRandomString());
        RoomOptions roomOptions = new RoomOptions {MaxPlayers=2,IsOpen = true,IsVisible = true };
        PhotonNetwork.JoinOrCreateRoom(PlayerPrefs.GetString("Code"), roomOptions, TypedLobby.Default);
    }


    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Game");
    }

    private const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789"; // Zeichen, aus denen der String generiert wird
    private const int stringLength = 5; // Länge des generierten Strings

    private string GenerateRandomString()
    {
        System.Random random = new System.Random();
        char[] stringChars = new char[stringLength];

        for (int i = 0; i < stringLength; i++)
        {
            stringChars[i] = chars[random.Next(chars.Length)];
        }

        return new string(stringChars);
    }


}
