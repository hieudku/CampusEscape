using UnityEngine;

public class NPCDialogTrigger : MonoBehaviour
{
    public string[] dialogLines;
    public DialogManager dialogManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            dialogManager.StartDialog(dialogLines);
        }
    }
}
