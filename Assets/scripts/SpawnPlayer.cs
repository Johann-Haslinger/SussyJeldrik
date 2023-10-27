using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnPlayer : MonoBehaviour
{
    public GameObject Player;
    void Start()
    {
        PhotonNetwork.Instantiate(Player.name,Vector3.zero, Quaternion.identity);
    }
}
