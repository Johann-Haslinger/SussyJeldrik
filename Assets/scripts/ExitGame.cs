using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGame : MonoBehaviour
{
    [System.Obsolete]
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BulletGegner"))
        {
            Debug.Log("Exit");
            Application.CancelQuit();


        }
    }
}
