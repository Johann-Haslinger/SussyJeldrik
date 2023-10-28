using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class RoomMananer : MonoBehaviour
{
    public TMP_InputField txt;
    public void Join()
    {
        PlayerPrefs.SetString("Code", txt.text);
        SceneManager.LoadScene("JoinLoading");
    }
}
