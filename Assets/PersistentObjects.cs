using UnityEngine;

public class PersistentObjects : MonoBehaviour
{
    private static bool hasSpawned = false;

    void Awake()
    {
        if (hasSpawned)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
            hasSpawned = true;
        }
    }
}
