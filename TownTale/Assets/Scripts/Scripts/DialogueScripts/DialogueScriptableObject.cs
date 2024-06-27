using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "NewDialogue", menuName = "Dialogue/DialogueScriptableObject")]
public class DialogueScriptableObject : ScriptableObject
{
    public string id;
    public string characterName;
    public string dialogueText;
    public Sprite avatar;
    public List<Choice> choices;
}

[System.Serializable]
public class Choice
{
    public string text;
    public int reputationChange;
    public List<DialogueScriptableObject> nextDialogues; // Multiple next dialogues
    public bool waitForTrigger; // Wait for trigger flag
    public string trigger; // Trigger identifier
}
