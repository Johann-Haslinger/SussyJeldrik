using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class SendDatas : MonoBehaviour
{
    public PhotonView view;

    void Start()
    {
        if(view.IsMine)
        {
            view.RPC("GetData", RpcTarget.AllBuffered, "Schnabel: Hallo.");
        }
    }

    [PunRPC]
    void GetData(string data)
    {
        Debug.Log(data);
    }

}
