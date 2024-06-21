using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class DialogueScriptableObjectGenerator : MonoBehaviour
{
    [MenuItem("Tools/Generate Dialogue ScriptableObjects")]
    public static void GenerateDialogueScriptableObjects()
    {
        // Load dialogue data
        List<DialogueData> dialogueDataList = DialogueDataList.GetDialogueData();

        // Dictionary to keep track of created dialogues for linking
        Dictionary<string, DialogueScriptableObject> createdDialogues = new Dictionary<string, DialogueScriptableObject>();

        // Path to save the ScriptableObjects
        string path = "Assets/Dialogues/";

        if (!AssetDatabase.IsValidFolder(path))
        {
            AssetDatabase.CreateFolder("Assets", "Dialogues");
        }

        // Create ScriptableObjects
        foreach (DialogueData dialogueData in dialogueDataList)
        {
            // Create a new DialogueScriptableObject
            DialogueScriptableObject dialogueSO = ScriptableObject.CreateInstance<DialogueScriptableObject>();
            dialogueSO.id = dialogueData.id;
            dialogueSO.characterName = dialogueData.characterName;
            dialogueSO.dialogueText = dialogueData.dialogueText;
            dialogueSO.choices = new List<Choice>();

            // Save the ScriptableObject as an asset
            string assetPath = $"{path}{dialogueData.id}.asset";
            AssetDatabase.CreateAsset(dialogueSO, assetPath);

            // Add to the dictionary
            createdDialogues.Add(dialogueData.id, dialogueSO);
        }

        // Link choices to their next dialogues
        foreach (DialogueData dialogueData in dialogueDataList)
        {
            DialogueScriptableObject dialogueSO = createdDialogues[dialogueData.id];

            foreach (ChoiceData choiceData in dialogueData.choices)
            {
                Choice choice = new Choice
                {
                    text = choiceData.text,
                    reputationChange = choiceData.reputationChange,
                    nextDialogue = createdDialogues.ContainsKey(choiceData.nextDialogueID) ? createdDialogues[choiceData.nextDialogueID] : null
                };

                dialogueSO.choices.Add(choice);
            }

            // Mark the asset as dirty to save the changes
            EditorUtility.SetDirty(dialogueSO);
        }

        // Save all assets and refresh the AssetDatabase
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();

        Debug.Log("Dialogue ScriptableObjects generated successfully!");
    }
}
