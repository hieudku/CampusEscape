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

        Transform spawnPoint = null;

        if (SpawnManager.entryPoint == "FromLibrary")
        {
            spawnPoint = GameObject.Find("LibraryExitSpawn")?.transform;
        }
        else if (SpawnManager.entryPoint == "FromCampus")
        {
            spawnPoint = GameObject.Find("FromCampusSpawn")?.transform;
        }
        else if (SpawnManager.entryPoint == "FromStaffOffice")
        {
            spawnPoint = GameObject.Find("StaffOfficeExitSpawn")?.transform;
        }

        if (spawnPoint != null)
        {
            player.transform.position = spawnPoint.position;
        }
        else
        {
            Debug.Log("Default spawn position used or spawn point not found.");
        }
    }
}
