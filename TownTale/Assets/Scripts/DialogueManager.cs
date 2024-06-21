using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

[System.Serializable]
public class Dialogue
{
    public string characterName;
    public string dialogueText;
    public List<string> choices;
    public List<int> nextDialogueIndices;
}

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI characterNameText; // TextMeshPro for character name
    public TextMeshProUGUI dialogueText;      // TextMeshPro for dialogue content
    public GameObject choicesPanel;           // Panel to hold choice buttons
    public Button choiceButtonPrefab;         // Prefab for choice buttons

    private List<Dialogue> dialogues;         // List to hold all dialogues
    private int currentDialogueIndex;         // Index of the current dialogue

    void Start()
    {
        dialogues = new List<Dialogue>();
        LoadDialogueData(); // Load dialogues (could be replaced with data from a file)
        DisplayDialogue(0); // Start by displaying the first dialogue
    }

    void LoadDialogueData()
    {
        // Example dialogues
        dialogues.Add(new Dialogue
        {
            characterName = "Mahsa",
            dialogueText = "Hello! I need your help. What will you do?",
            choices = new List<string> { "Help Mahsa", "Ignore Mahsa" },
            nextDialogueIndices = new List<int> { 1, 2 }
        });

        dialogues.Add(new Dialogue
        {
            characterName = "Mahsa",
            dialogueText = "Thank you for helping! Let's get started.",
            choices = new List<string> { "Continue" },
            nextDialogueIndices = new List<int> { 3 }
        });

        dialogues.Add(new Dialogue
        {
            characterName = "Mahsa",
            dialogueText = "Oh, okay... I'll find someone else.",
            choices = new List<string> { "Continue" },
            nextDialogueIndices = new List<int> { 4 }
        });

        dialogues.Add(new Dialogue
        {
            characterName = "Narrator",
            dialogueText = "You and Mahsa start working together. ",
            choices = new List<string> { },
            nextDialogueIndices = new List<int> { }
        });

        dialogues.Add(new Dialogue
        {
            characterName = "Narrator",
            dialogueText = "You walk away from Mahsa. ",
            choices = new List<string> { },
            nextDialogueIndices = new List<int> { }
        });
    }

    public void DisplayDialogue(int index)
    {
        currentDialogueIndex = index;
        Dialogue dialogue = dialogues[index];

        characterNameText.text = dialogue.characterName;
        dialogueText.text = dialogue.dialogueText;

        // Clear existing choices
        foreach (Transform child in choicesPanel.transform)
        {
            Destroy(child.gameObject);
        }

        // Display new choices
        for (int i = 0; i < dialogue.choices.Count; i++)
        {
            Button choiceButton = Instantiate(choiceButtonPrefab, choicesPanel.transform);
            TextMeshProUGUI buttonTextTMP = choiceButton.GetComponentInChildren<TextMeshProUGUI>();
            if (buttonTextTMP != null)
            {
                buttonTextTMP.text = dialogue.choices[i];
            }
            int choiceIndex = i; // Local copy for the listener
            choiceButton.onClick.AddListener(() => OnChoiceSelected(choiceIndex));
        }
    }

    void OnChoiceSelected(int choiceIndex)
    {
        Dialogue dialogue = dialogues[currentDialogueIndex];
        if (dialogue.nextDialogueIndices.Count > choiceIndex)
        {
            int nextIndex = dialogue.nextDialogueIndices[choiceIndex];
            DisplayDialogue(nextIndex);
        }
    }
}