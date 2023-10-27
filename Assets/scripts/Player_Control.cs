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

    private void Start()
    {
        gegner = GameObject.FindGameObjectWithTag("Gegner");
    }

    void Update()
    {
        if (view.IsMine)
        {
            if (Input.GetKey(KeyCode.W))
            {
                transform.position += Vector3.up * Speed;
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.position += Vector3.down * Speed;
            }

            transform.position = new Vector3(transform.position.x,Mathf.Clamp(transform.position.y,minY,maxY), transform.position.z);

            view.RPC("SendPos", RpcTarget.All, transform.position.x, transform.position.y);
        }
    }

    [PunRPC]
    void SendPos(float x, float y)
    {
        if (view.IsMine)
        {
            gegner.transform.transform.position = new Vector3(x, y, 0);
        }
    }

}
