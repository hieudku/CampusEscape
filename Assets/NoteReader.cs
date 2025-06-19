using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class NoteReader : MonoBehaviour
{
    public GameObject notePanel;
    public TextMeshProUGUI noteText;
    public Button closeButton;

    void Start()
    {
        notePanel.SetActive(false);
        closeButton.onClick.AddListener(HideNote);
    }

    public void ShowNote(string content)
    {
        noteText.text = content;
        notePanel.SetActive(true);
        Time.timeScale = 0f; // Pause game while reading
    }

    public void HideNote()
    {
        notePanel.SetActive(false);
        Time.timeScale = 1f; // Resume game
    }
}
