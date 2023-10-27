using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    // Diese Methode wird vom UI-Button aufgerufen, wenn er geklickt wird.
    public void ChangeScene(string sceneName)
    {
        // Lade die angegebene Szene.
        SceneManager.LoadScene(sceneName);
    }
}
