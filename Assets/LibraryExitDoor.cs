using UnityEngine;
using UnityEngine.SceneManagement;

public class LibraryExitDoor : MonoBehaviour
{
    public string targetScene = "GameScene"; // The scene to load when exiting
    public string spawnId = "FromLibrary";     // The spawn point to use in the target scene

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SpawnManager.entryPoint = spawnId;
            SceneManager.LoadScene(targetScene);
        }
    }
}
