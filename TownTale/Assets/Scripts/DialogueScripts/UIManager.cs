using UnityEngine;

public class UIManager : MonoBehaviour
{
    public DialogueManager dialogueManager; // Reference to the DialogueManager

    public void OnSaveButtonClicked()
    {
        dialogueManager.SaveGame();
    }

    public void OnLoadButtonClicked()
    {
        dialogueManager.LoadGame();
    }
}
