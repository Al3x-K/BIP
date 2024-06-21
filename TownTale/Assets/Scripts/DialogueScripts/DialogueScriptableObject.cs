using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewDialogue", menuName = "Dialogue/DialogueScriptableObject")]
public class DialogueScriptableObject : ScriptableObject
{
    public string id;
    public string characterName;
    public string dialogueText;
    public List<Choice> choices;
}

[System.Serializable]
public class Choice
{
    public string text;
    public int reputationChange;
    public DialogueScriptableObject nextDialogue;
}
