using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBarHandler : MonoBehaviour
{
    public Image Healthbar;
    public PlayerData playerdata;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerdata.health = 100;
    }

    // Update is called once per frame
    void Update()
    {
        Healthbar.fillAmount = playerdata.health / 100;
    }
}
