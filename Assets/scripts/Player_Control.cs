using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
using UnityEngine.SceneManagement;

public class Player_Control : MonoBehaviour
{
    public float Speed;

    public PhotonView view;

    public float maxY, minY;

    public GameObject gegner,bullet,bulletGegner;

    public Transform Player;


    public float bulletSpeed;

    public AudioSource sr;
    private void Start()
    {
        gegner = GameObject.FindGameObjectWithTag("Gegner");
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        bulletGegner = GameObject.FindGameObjectWithTag("BulletGegner");
        bullet = GameObject.FindGameObjectWithTag("Bullet");
        sr = GameObject.Find("bub").GetComponent<AudioSource>();
    }

    void Update()
    {
        if (view.IsMine)
        {
             Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (Input.GetKey(KeyCode.W))
            {
                Player.position += Vector3.up * Speed;
            }
            if (Input.GetKey(KeyCode.S))
            {
                Player.position += Vector3.down * Speed;
            }

            Player.position = new Vector3(Player.position.x,Mathf.Clamp(Player.position.y,minY,maxY), Player.position.z);

            if(Input.GetKeyDown(KeyCode.Space))
            {
                bullet.transform.position = Player.position;
                bullet.transform.LookAt(mousePos);
                sr.Play();
            }

            bullet.transform.Translate(Vector3.forward * Time.deltaTime * bulletSpeed);
            view.RPC("SendBullPos", RpcTarget.Others, -bullet.transform.position.x, bullet.transform.position.y);

            view.RPC("SendPos", RpcTarget.Others, -Player.position.x, Player.position.y);


            if(Vector3.Distance(Player.position, bulletGegner.transform.position) <= 0.5)
            {
                Debug.Log("Exit");
                view.RPC("SendWin", RpcTarget.Others);
                SceneManager.LoadScene("Lose");
            }

        }
    }

    [PunRPC]
    void SendPos(float x, float y)
    {
        if(gegner!= null)
        gegner.transform.transform.position = new Vector3(x, y, 0);

    }
    [PunRPC]
    void SendBullPos(float x, float y)
    {
        if (bulletGegner != null)
            bulletGegner.transform.transform.position = new Vector3(x, y, 0);

    }

        [PunRPC]
        void SendWin()
        {
        SceneManager.LoadScene("Win");
    }

    }
