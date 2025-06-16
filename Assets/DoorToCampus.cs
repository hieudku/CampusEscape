using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorToCampus : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene("GameScene");
        }
    }
}
