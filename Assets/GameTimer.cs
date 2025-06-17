using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    public static GameTimer Instance;
    public string GameScene;

    public TextMeshProUGUI timerText;
    public GameObject gameOverPanel;
    public AudioSource gameOverSound;

    public Button restartButton;
    public Button quitButton;


    private float totalTime = 360f; // 10 minutes = 600 seconds (from 23:50 to 00:00)
    private bool timerRunning = true;

    void Start()
    {
        if (string.IsNullOrEmpty(GameScene))
        {
            GameScene = "StartScene";
        }
        Time.timeScale = 1f;
        restartButton.onClick.AddListener(RestartGame);
        quitButton.onClick.AddListener(QuitGame);
    }

    void Awake()
    {
        Instance = this;
        Time.timeScale = 1f;
    }

    public void TriggerGameOver()
    {
        Debug.Log("Game Over triggered!");
        Time.timeScale = 0f;

        if (gameOverSound != null) gameOverSound.Play();
        if (gameOverPanel != null) gameOverPanel.SetActive(true);
    }


    void Update()
    {
        if (!timerRunning) return;

        totalTime -= Time.deltaTime;
        if (totalTime <= 0f)
        {
            totalTime = 0f;
            timerRunning = false;
            HandleTimeExpired();
        }

        UpdateTimerDisplay();
    }

    void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(totalTime / 60);
        int seconds = Mathf.FloorToInt(totalTime % 60);
        timerText.text = $"Time Left: {minutes:D2}:{seconds:D2}";
    }



    void HandleTimeExpired()
    {
        Debug.Log("Time's up! Game Over.");
        Time.timeScale = 0f;

        if (gameOverSound != null)
            gameOverSound.Play();

        if (gameOverPanel != null)
            gameOverPanel.SetActive(true);


        Time.timeScale = 0f;

        // Disable the player object
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null) player.SetActive(false);
    }

    public void RestartGame()
    {
        Time.timeScale = 1f; // Resume time before restarting
        gameOverPanel.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        Time.timeScale = 1f; // Resume time before going to main menu or exit
        gameOverPanel.SetActive(false);
        SceneManager.LoadScene("StartScene");
    }
}