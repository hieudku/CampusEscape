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
        Time.timeScale = 1f;

        DestroyDontDestroyOnLoadObjects();

        loading.gameObject.SetActive(true);
        SpawnManager.entryPoint = "FromStart";
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
    void DestroyDontDestroyOnLoadObjects()
    {
        GameObject temp = new GameObject("Temp");
        DontDestroyOnLoad(temp);
        Scene dontDestroyOnLoadScene = temp.scene;
        Destroy(temp);

        GameObject[] rootObjects = dontDestroyOnLoadScene.GetRootGameObjects();
        foreach (GameObject obj in rootObjects)
        {
            if (obj.name != "EventSystem")
            {
                Destroy(obj);
            }
        }
    }
}
