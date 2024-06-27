using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.IO;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance { get; private set; }

    public TextMeshProUGUI characterNameText;
    public TextMeshProUGUI dialogueText;
    public GameObject choicesPanel;
    public Button choiceButtonPrefab;
    public TextMeshProUGUI reputationText;
    public Image avatarImage;

    public List<DialogueScriptableObject> allDialogues;
    public DialogueScriptableObject startingDialogue;
    public ReputationManager reputationManager;

    private DialogueScriptableObject currentDialogue;
    private bool waitingForTrigger = false;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        PrintSaveFilePath();

        if (File.Exists(GetSaveFilePath()))
        {
            Debug.Log("Save file found. Loading game...");
            LoadGame();
        }
        else
        {
            Debug.Log("No save file found. Starting new dialogue.");
            DisplayDialogue(startingDialogue);
        }
    }

    public void DisplayDialogue(DialogueScriptableObject dialogue)
    {
        if (dialogue == null)
        {
            Debug.LogError("DisplayDialogue called with a null dialogue!");
            return;
        }

        currentDialogue = dialogue;
        characterNameText.text = dialogue.characterName;
        dialogueText.text = dialogue.dialogueText;
        avatarImage.sprite = dialogue.avatar;

        foreach (Transform child in choicesPanel.transform)
        {
            Destroy(child.gameObject);
        }

        foreach (Choice choice in dialogue.choices)
        {
            Button choiceButton = Instantiate(choiceButtonPrefab, choicesPanel.transform);
            TextMeshProUGUI buttonTextTMP = choiceButton.GetComponentInChildren<TextMeshProUGUI>();
            buttonTextTMP.text = choice.text;
            choiceButton.onClick.AddListener(() => OnChoiceSelected(choice));
        }
    }

    void OnChoiceSelected(Choice choice)
    {
        reputationManager.AddReputation(choice.reputationChange);

        if (choice.waitForTrigger)
        {
            waitingForTrigger = true;
        }
        else
        {
            DisplayNextDialogue(choice);
        }

        UpdateReputationUI();
    }

    public void TriggerNextDialogue(string trigger)
    {
        if (waitingForTrigger)
        {
            foreach (var choice in currentDialogue.choices)
            {
                if (choice.trigger == trigger)
                {
                    DisplayNextDialogue(choice);
                    waitingForTrigger = false;
                    break;
                }
            }
        }
    }

    void DisplayNextDialogue(Choice choice)
    {
        if (choice.nextDialogues != null && choice.nextDialogues.Count > 0)
        {
            var nextDialogue = choice.nextDialogues[0]; // For simplicity, we pick the first one. Adjust as necessary.
            currentDialogue = nextDialogue;
            DisplayDialogue(currentDialogue);
        }
        else
        {
            EndConversation();
        }
    }

    void UpdateReputationUI()
    {
        reputationText.text = $"Reputation: {reputationManager.ReputationPoints} ({reputationManager.CurrentLevel})";
    }

    public void SaveGame()
    {
        if (currentDialogue != null && !string.IsNullOrEmpty(currentDialogue.id))
        {
            GameData gameData = new GameData
            {
                reputationPoints = reputationManager.ReputationPoints,
                currentDialogueID = currentDialogue.id
            };

            string json = JsonUtility.ToJson(gameData);
            File.WriteAllText(GetSaveFilePath(), json);
            Debug.Log("Game Saved");
        }
        else
        {
            Debug.LogError("Cannot save game: currentDialogue is null or has no valid ID.");
        }
    }

    public void LoadGame()
    {
        string json = File.ReadAllText(GetSaveFilePath());
        GameData gameData = JsonUtility.FromJson<GameData>(json);

        currentDialogue = allDialogues.Find(d => d.id == gameData.currentDialogueID);
        if (currentDialogue != null)
        {
            DisplayDialogue(currentDialogue);
        }
        else
        {
            Debug.LogError("Current dialogue not found in allDialogues list!");
            DisplayDialogue(startingDialogue);
        }

        UpdateReputationUI();
    }

    private string GetSaveFilePath()
    {
        return Path.Combine(Application.persistentDataPath, "savefile.json");
    }

    public void EndConversation()
    {
        characterNameText.text = "";
        dialogueText.text = "Thank you for playing!";
        foreach (Transform child in choicesPanel.transform)
        {
            Destroy(child.gameObject);
        }
    }

    private void PrintSaveFilePath()
    {
        Debug.Log("Save file path: " + GetSaveFilePath());
    }
}

[System.Serializable]
public class GameData
{
    public int reputationPoints;
    public string currentDialogueID;
}
