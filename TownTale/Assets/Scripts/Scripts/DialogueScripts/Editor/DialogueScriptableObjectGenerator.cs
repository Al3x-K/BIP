using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public static class DialogueScriptableObjectGenerator
{
    // Menu item to generate dialogue scriptable objects
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
            dialogueSO.id = dialogueData.Id;
            dialogueSO.characterName = dialogueData.CharacterName;
            dialogueSO.dialogueText = dialogueData.DialogueText;
            dialogueSO.choices = new List<Choice>();

            // Save the ScriptableObject as an asset
            string assetPath = $"{path}{dialogueData.Id}.asset";
            AssetDatabase.CreateAsset(dialogueSO, assetPath);

            // Add to the dictionary
            createdDialogues.Add(dialogueData.Id, dialogueSO);
        }

        // Link choices to their next dialogues
        foreach (DialogueData dialogueData in dialogueDataList)
        {
            DialogueScriptableObject dialogueSO = createdDialogues[dialogueData.Id];

            foreach (ChoiceData choiceData in dialogueData.Choices)
            {
                Choice choice = new Choice
                {
                    text = choiceData.Text,
                    reputationChange = choiceData.ReputationChange,
                    nextDialogues = new List<DialogueScriptableObject>(),
                    waitForTrigger = choiceData.WaitForTrigger,
                    trigger = choiceData.Trigger
                };

                if (choiceData.NextDialogueIDs != null)
                {
                    foreach (var nextDialogueID in choiceData.NextDialogueIDs)
                    {
                        if (createdDialogues.ContainsKey(nextDialogueID))
                        {
                            choice.nextDialogues.Add(createdDialogues[nextDialogueID]);
                        }
                    }
                }

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

    // Menu item to assign avatars to dialogues
    [MenuItem("Tools/Assign Avatars")]
    public static void AssignAvatars()
    {
        AvatarAssigner avatarAssigner = Object.FindObjectOfType<AvatarAssigner>();
        if (avatarAssigner != null)
        {
            avatarAssigner.AssignAvatars();
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }
        else
        {
            Debug.LogError("No AvatarAssigner component found in the scene.");
        }
    }
}
