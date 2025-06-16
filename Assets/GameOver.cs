using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverPanel;

    public void ShowGameOver()
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void HideGameOver()
    {
        gameOverPanel.SetActive(false);
        Time.timeScale = 1f;
    }
}