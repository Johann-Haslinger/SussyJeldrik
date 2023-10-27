using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Player_Control : MonoBehaviour
{
    public float Speed;

    public PhotonView view;

    void Update()
    {
        if (view.IsMine)
        {
            if (Input.GetKey(KeyCode.W))
            {
                transform.position += Vector3.up * Speed;
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.position += Vector3.left * Speed;
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.position += Vector3.right * Speed;
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.position += Vector3.down * Speed;
            }
        }
    }
}
