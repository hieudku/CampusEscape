using UnityEngine;

public class SubmitAssignment : MonoBehaviour
{
    public GameObject submissionPanel;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Inventory.HasItem("AssignmentFile"))
            {
                Debug.Log("Assignment submitted!");
                submissionPanel.SetActive(true); // Show message
                // freeze movement or hide player
            }
            else
            {
                Debug.Log("You don't have the assignment.");
            }
        }
    }
}
