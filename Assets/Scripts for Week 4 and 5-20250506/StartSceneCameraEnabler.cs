using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneCameraEnabler : MonoBehaviour
{
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "StartScene")
        {
            Camera.main.enabled = true;

            AudioListener listener = Camera.main.GetComponent<AudioListener>();
            if (listener != null)
                listener.enabled = true;
        }
    }
}
