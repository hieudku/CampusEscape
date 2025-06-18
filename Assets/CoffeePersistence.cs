using UnityEngine;
using TMPro;

public class CoffeePersistence : MonoBehaviour
{
    public TextMeshProUGUI coffeeText;
    public PlayerData playerdata;

    void Start()
    {
        HideCollectedCoffees();
        UpdateCoffeeUI();
    }

    void HideCollectedCoffees()
    {
        GameObject[] coffees = GameObject.FindGameObjectsWithTag("Coffee");
        foreach (GameObject coffee in coffees)
        {
            if (PlayerPrefs.HasKey(coffee.name))
            {
                coffee.SetActive(false);
            }
        }
    }

    public void UpdateCoffeeUI()
    {
        coffeeText.text = $"Coffee Collected: {playerdata.score}/10";
    }
}
