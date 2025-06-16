using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class HealthController : MonoBehaviour
{
    public TextMeshProUGUI HealthText; // Reference to the TextMeshProUGUI component
    public PlayerData playerdata;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerdata.health = 100; // Initialize the health to 100
        HealthText.text = "Health: " + playerdata.health; // Update the UI text with the initial health
    }

    // Update is called once per frame
    void Update()
    {
        HealthText.text = "Health: " + playerdata.health;
    }
}
