using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestManager : MonoBehaviour
{
    public TextMeshProUGUI questText;
    public List<Quest> activeQuests = new List<Quest>();
    public static QuestManager Instance;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // Add a default quest
        AddQuest(new Quest("Find the Library", "Locate and enter the campus library."));
    }

    public void AddQuest(Quest quest)
    {
        activeQuests.Add(quest);
        UpdateQuestUI();
    }

    public void CompleteQuest(string questName)
    {
        Quest quest = activeQuests.Find(q => q.questName == questName);
        if (quest != null)
        {
            quest.isCompleted = true;
            UpdateQuestUI();
        }
    }

    private void UpdateQuestUI()
    {
        questText.text = "";
        foreach (Quest quest in activeQuests)
        {
            questText.text += (quest.isCompleted ? "<color=green>" : "<color=white>");
            questText.text += $"{quest.questName}: {quest.description}</color>\n";
        }
    }
}
