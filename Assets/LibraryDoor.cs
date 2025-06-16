using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorToLibrary : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SpawnManager.entryPoint = "FromCampus";
            SceneManager.LoadScene("LibraryScene");
        }
    }
}

