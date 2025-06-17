using UnityEngine;

public class QuestGiver : MonoBehaviour
{
    public Quest quest;

    private bool hasGivenQuest = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasGivenQuest)
        {
            QuestManager.Instance.AddQuest(quest);
            hasGivenQuest = true;
        }
    }
}