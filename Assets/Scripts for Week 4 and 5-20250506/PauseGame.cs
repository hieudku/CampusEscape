using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseGame : MonoBehaviour
{
    
    public Toggle PauseButton;
    public PlayerData playerdata;

    // Start is called before the first frame update
    void Start()
    {
        PauseButton.isOn = false;
    }


        
    // Update is called once per frame
    void Update()
    {
        
        
    if (PauseButton.isOn)
    { 
        Time.timeScale = 0;

    }
    else
    {
        Time.timeScale = 1;
    }
        
    }
}
