using UnityEngine;
using TMPro;

public class CoffeeManager : MonoBehaviour
{
    public static CoffeeManager Instance;

    public int coffeeCollected = 0;
    public int totalCoffee = 10;

    public TextMeshProUGUI coffeeText;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void CollectCoffee()
    {
        coffeeCollected++;
        UpdateCoffeeUI();
    }

    public void UpdateCoffeeUI()
    {
        if (coffeeText != null)
        {
            coffeeText.text = $"Coffee: {coffeeCollected}/{totalCoffee}";
        }
    }
}
