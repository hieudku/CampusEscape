using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class BeginGame : MonoBehaviour

     
{
    public Button BeginButton;
   // public Toggle Soundtoggle;
    public TextMeshProUGUI loading;
    public string GameScene;
    public AudioSource bmusic;

    // Start is called before the first frame update
    void Start()
    {
        Button Begbtn = BeginButton.GetComponent<Button>();
        Begbtn.onClick.AddListener(TaskOnClickBeg);
        loading.gameObject.SetActive(false);
    }

    void TaskOnClickBeg()
    {
        Debug.Log("You have clicked Begin Button!");
        loading.gameObject.SetActive(true);
        SceneManager.LoadScene(GameScene);
    }

    // Update is called once per frame
    void Update()
    {
       /* if (Soundtoggle.isOn)
        {
            bmusic.mute = true;
        }
        else
        {
            bmusic.mute = false;
        }
       */


    }
}
