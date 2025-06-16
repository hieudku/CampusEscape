using UnityEngine;
using UnityEngine.SceneManagement;

public class SubmitAssignment : MonoBehaviour
{
    public string requiredItem = "AssignmentFile";
    public string successScene = "WinScene";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Inventory.HasItem(requiredItem))
            {
                Debug.Log("Assignment submitted successfully!");

                // Optionally load win scene
                if (!string.IsNullOrEmpty(successScene))
                {
                    SceneManager.LoadScene(successScene);
                }

               
            }
            else
            {
                Debug.Log("You don't have the assignment yet.");

            }
        }
    }
}
