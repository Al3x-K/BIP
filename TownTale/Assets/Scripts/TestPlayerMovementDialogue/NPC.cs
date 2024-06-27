using UnityEngine;

public class NPC : MonoBehaviour
{
    public DialogueScriptableObject dialogue;

    public void StartDialogue()
    {
        DialogueManager.Instance.DisplayDialogue(dialogue);
    }

    public void EndDialogue()
    {
        DialogueManager.Instance.EndConversation();
    }
}
