using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGame : MonoBehaviour
{
    [System.Obsolete]
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("BulletGegner")) 
            Application.CancelQuit();
    }
}
