using UnityEngine;
using TMPro;

public class DialogManager : MonoBehaviour
{
    public GameObject questPanel;
    private string[] dialogLines;
    public GameObject dialogPanel;
    public TextMeshProUGUI dialogText;
    [SerializeField] private QuestManager questManager; // Link to quest manager
    private int currentLine = 0;

    public void StartDialog(string[] lines)
    {
        dialogLines = lines;
        currentLine = 0;
        dialogPanel.SetActive(true);
        ShowLine();
    }

    public void ShowLine()
    {
        if (currentLine < dialogLines.Length)
        {
            dialogText.text = dialogLines[currentLine];
            currentLine++;
        }
        else
        {
            dialogPanel.SetActive(false);

            // Show quest panel after dialog ends
            if (questPanel != null)
                questPanel.SetActive(true);

            // Add quests
            if (QuestManager.Instance != null)
            {
                QuestManager.Instance.AddQuest(new Quest("1. Find the Assignment", "Locate the lost assignment file."));
                QuestManager.Instance.AddQuest(new Quest("2. Find the Swipe Card", "Retrieve the staff swipe card to access the office."));
                QuestManager.Instance.AddQuest(new Quest("3. Submit the Assignment", "Bring the assignment to the Staff Office for submission."));
            }
        }
    }
}
