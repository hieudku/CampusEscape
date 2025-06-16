using UnityEngine;
using UnityEngine.SceneManagement;

public class StaffOfficeDoor : MonoBehaviour
{
    public string requiredKey = "SwipeCard";
    public string targetScene = "StaffOfficeScene";
    public string spawnId = "FromCampus";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Inventory.HasItem(requiredKey))
            {
                SpawnManager.entryPoint = spawnId;
                SceneManager.LoadScene(targetScene);
            }
            else
            {
                Debug.Log("You need a Swipe Card to enter the Staff Office.");
                // Optional: Show UI message
            }
        }
    }
}
