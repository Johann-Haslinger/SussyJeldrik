using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Player_Control : MonoBehaviour
{
    public float Speed;

    public PhotonView view;

    public float maxY, minY;

    public GameObject gegner;

    public Transform Player;

    private void Start()
    {
        gegner = GameObject.FindGameObjectWithTag("Gegner");
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (view.IsMine)
        {
            if (Input.GetKey(KeyCode.W))
            {
                Player.position += Vector3.up * Speed;
            }
            if (Input.GetKey(KeyCode.S))
            {
                Player.position += Vector3.down * Speed;
            }

            Player.position = new Vector3(Player.position.x,Mathf.Clamp(Player.position.y,minY,maxY), Player.position.z);

            view.RPC("SendPos", RpcTarget.All, Player.position.x, Player.position.y, view.ViewID);
        }
    }

    [PunRPC]
    void SendPos(float x, float y,int id)
    {
        Debug.Log(view.ViewID + " | " + id);
        if (view.ViewID != id)
        {
            gegner.transform.transform.position = new Vector3(x, y, 0);
        }
    }

}
