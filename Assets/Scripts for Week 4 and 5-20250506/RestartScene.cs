using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class RestartScene : MonoBehaviour

    
{   public Button RestartButton;
    
    // Start is called before the first frame update
    void Start()
    {
        Button btn6 = RestartButton.GetComponent<Button>();
        btn6.onClick.AddListener(TaskOnClick6);
    }

    void TaskOnClick6()
    {
        Debug.Log("You have clicked RESET!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
