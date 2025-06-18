using System.Collections.Generic;
using UnityEngine;

public class PersistentObjects : MonoBehaviour
{
    public static PersistentObjects Instance;

    public HashSet<string> collectedCoffees = new HashSet<string>();

    private static bool hasSpawned = false;

    void Awake()
    {
        if (hasSpawned)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        hasSpawned = true;
    }
}
