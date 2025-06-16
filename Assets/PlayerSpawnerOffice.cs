using UnityEngine;

public class PlayerSpawnerOffice : MonoBehaviour
{
    void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");

        if (SpawnManager.entryPoint == "FromCampus")
        {
            player.transform.position = GameObject.Find("FromCampusSpawn").transform.position;
        }
        else
        {
            Debug.Log("Default spawn position used.");
        }
    }
}
