using UnityEngine;

public class AssignmentPickup : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Inventory.AddItem("AssignmentFile");
            Debug.Log("Assignment picked up!");
            Destroy(gameObject);
            if (QuestManager.Instance != null)
            {
                QuestManager.Instance.CompleteQuest("Find the Assignment");
            }
        }
    }
}
