using UnityEngine;

public class SwipeCardPickup : MonoBehaviour
{
    public static bool hasCard = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Inventory.AddItem("SwipeCard");
            hasCard = true;
            Debug.Log("Swipe Card picked up!");
            Destroy(gameObject);
        }
    }
}

