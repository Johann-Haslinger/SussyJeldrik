using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGame : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("BulletGegner"))
        {
            Debug.Log("Exit");
            Application.CancelQuit();


        }
    }
}
