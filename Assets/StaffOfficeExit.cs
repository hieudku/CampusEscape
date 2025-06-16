using UnityEngine;
using UnityEngine.SceneManagement;

public class StaffOfficeExit : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SpawnManager.entryPoint = "FromStaffOffice";
            SceneManager.LoadScene("GameScene");
        }
    }
}

