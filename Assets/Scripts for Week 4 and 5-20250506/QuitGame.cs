using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitGame : MonoBehaviour
{

    public Button QuitButton;
    public string GameScene;

    // Start is called before the first frame update
    void Start()
    {
        Button Quitbtn = QuitButton.GetComponent<Button>();
        Quitbtn.onClick.AddListener(TaskOnClickQuit);
    }
    void TaskOnClickQuit()
    {
        Debug.Log("You have clicked Quit Button!");
        SceneManager.LoadScene(GameScene);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
