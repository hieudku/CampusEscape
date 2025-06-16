using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");

        if (player == null)
        {
            Debug.LogError("Player not found!");
            return;
        }

        if (SpawnManager.entryPoint == "FromLibrary")
        {
            Transform spawnPoint = GameObject.Find("LibraryExitSpawn")?.transform;
            if (spawnPoint != null) player.transform.position = spawnPoint.position;
        }
        else if (SpawnManager.entryPoint == "FromCampus")
        {
            Transform spawnPoint = GameObject.Find("FromCampusSpawn")?.transform;
            if (spawnPoint != null) player.transform.position = spawnPoint.position;
        }
        else
        {
            Debug.Log("Default spawn position used.");
        }
    }
}

