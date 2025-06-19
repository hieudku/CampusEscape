using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SubmitAssignment : MonoBehaviour
{
    public GameObject submissionPanel;
    public TextMeshProUGUI coffeeText;
    public TextMeshProUGUI timeText;
    public Button quitButton;

    private bool hasSubmitted = false;

    private void Start()
    {
        if (submissionPanel != null)
        {
            submissionPanel.SetActive(false);
        }

        quitButton.onClick.AddListener(QuitToStart);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (hasSubmitted) return;

        if (other.CompareTag("Player") && Inventory.HasItem("AssignmentFile"))
        {
            hasSubmitted = true;
            Debug.Log("Assignment submitted!");
            ShowWinPanel();
        }
        else
        {
            Debug.Log("You don't have the assignment.");
        }
    }

    void ShowWinPanel()
    {
        Time.timeScale = 0f;
        submissionPanel.SetActive(true);

        // Time taken
        float timeElapsed = FindObjectOfType<GameTimer>().GetTimeElapsed();
        int minutes = Mathf.FloorToInt(timeElapsed / 60f);
        int seconds = Mathf.FloorToInt(timeElapsed % 60f);
        timeText.text = $"Time Taken: {minutes:00}:{seconds:00}";

        // Coffee collected
        int coffeeCount = FindObjectOfType<PlayerData>().score;
        coffeeText.text = $"Coffee Collected: {coffeeCount}/10";
    }

    void QuitToStart()
    {
        Time.timeScale = 1f;
        SpawnManager.entryPoint = "FromStart";
        SceneManager.LoadScene("StartScene");
    }
}

