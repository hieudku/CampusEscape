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

        Debug.Log("Spawn entry point: " + SpawnManager.entryPoint);

        Transform spawnPoint = null;

        if (SpawnManager.entryPoint == "FromLibrary")
            spawnPoint = GameObject.Find("LibraryExitSpawn")?.transform;
        else if (SpawnManager.entryPoint == "FromCampus")
            spawnPoint = GameObject.Find("FromCampusSpawn")?.transform;
        else if (SpawnManager.entryPoint == "FromStaffOffice")
            spawnPoint = GameObject.Find("StaffOfficeExitSpawn")?.transform;

        if (spawnPoint == null)
        {
            spawnPoint = GameObject.Find("DefaultSpawn")?.transform;
            Debug.LogWarning("No entry point found. Using default spawn.");
        }

        if (spawnPoint != null)
        {
            player.transform.position = spawnPoint.position;
            Debug.Log("Player spawned at: " + spawnPoint.name);
        }
        else
        {
            Debug.LogError("No spawn point found at all!");
        }

        Time.timeScale = 1f;
    }

}