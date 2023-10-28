using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;

public class SpawnPlayer : MonoBehaviour
{
    public TMP_Text txt;
    public GameObject Player;
    void Start()
    {
        txt.text = PlayerPrefs.GetString("Code");
        PhotonNetwork.Instantiate(Player.name,transform.position, Player.transform.rotation);
    }
}
