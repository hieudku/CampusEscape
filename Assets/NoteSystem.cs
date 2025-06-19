using UnityEngine;

public class Note : MonoBehaviour
{
    [TextArea]
    public string noteContent;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<NoteReader>().ShowNote(noteContent);
        }
    }
}
