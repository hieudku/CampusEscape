using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ScoreController : MonoBehaviour
{
    public TextMeshProUGUI ScoreText; // Reference to the TextMeshProUGUI component
    public PlayerData playerdata; // Reference to the PlayerData scriptable object
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerdata.score = 0; // Initialize the score to 0
        ScoreText.text = "Score: " + playerdata.score; // Update the UI text with the initial score
    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = "Score: " + playerdata.score;
    }
}
