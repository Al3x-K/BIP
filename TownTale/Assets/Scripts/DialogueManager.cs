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
    public Image background;                  // Background image for different scenes
    public Image characterPortrait;           // Character portrait

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
        // Day 1: Welcome Day - Introduction to the Town and Its Residents

        dialogues.Add(new Dialogue
        {
            characterName = "Narrator",
            dialogueText = "Welcome to TownTale, where every choice shapes our destiny. You must be the new face everyone’s been buzzing about! Here in TownTale, every conversation, every task you take on has the potential to bring us together or... stir things up. It’s all in how you choose to interact with your fellow townsfolk. Good luck, and may your tale in TownTale be a memorable one!",
            choices = new List<string> { "Continue" },
            nextDialogueIndices = new List<int> { 1 }
        });

        dialogues.Add(new Dialogue
        {
            characterName = "Player",
            dialogueText = "Hi, Aunt Marilyn! I’m excited to be here. What’s the plan for today?",
            choices = new List<string> { "Continue" },
            nextDialogueIndices = new List<int> { 2 }
        });

        dialogues.Add(new Dialogue
        {
            characterName = "Marilyn Brooks",
            dialogueText = "Hello, dear! It’s wonderful to have you here. Today, we’ll start with a tour of the Community Center, the beating heart of our town. After that, I’ll introduce you to some of our key residents and show you their workplaces.",
            choices = new List<string> { "Sounds perfect!" },
            nextDialogueIndices = new List<int> { 3 }
        });

        dialogues.Add(new Dialogue
        {
            characterName = "Player",
            dialogueText = "That sounds perfect! I can’t wait to get started.",
            choices = new List<string> { "Continue" },
            nextDialogueIndices = new List<int> { 4 }
        });

        // Guided Tour at the Community Center

        dialogues.Add(new Dialogue
        {
            characterName = "Marilyn Brooks",
            dialogueText = "[At the Community Center]\nThis is our Community Center. It’s where we gather for events, meetings, and celebrations. It’s the hub of our town’s activities. Over here, we have the hall of history.",
            choices = new List<string> { "Wow, fascinating!" },
            nextDialogueIndices = new List<int> { 5 }
        });

        dialogues.Add(new Dialogue
        {
            characterName = "Player",
            dialogueText = "Wow, these old photos and artifacts are fascinating. How long has the town been around?",
            choices = new List<string> { "Continue" },
            nextDialogueIndices = new List<int> { 6 }
        });

        dialogues.Add(new Dialogue
        {
            characterName = "Marilyn Brooks",
            dialogueText = "TownTale was founded over a hundred years ago. We’ve kept a lot of our history alive through these exhibits. Each item tells a story about our journey from a small settlement to the vibrant community we are today.",
            choices = new List<string> { "It's incredible!" },
            nextDialogueIndices = new List<int> { 7 }
        });

        dialogues.Add(new Dialogue
        {
            characterName = "Player",
            dialogueText = "It’s incredible to see how much the town has grown. What kind of events do you host here?",
            choices = new List<string> { "Continue" },
            nextDialogueIndices = new List<int> { 8 }
        });

        dialogues.Add(new Dialogue
        {
            characterName = "Marilyn Brooks",
            dialogueText = "We host everything from town meetings to festivals. This hall has seen weddings, community dinners, and even some heated debates! It’s a place where everyone’s voice can be heard.",
            choices = new List<string> { "Heart and soul!" },
            nextDialogueIndices = new List<int> { 9 }
        });

        dialogues.Add(new Dialogue
        {
            characterName = "Player",
            dialogueText = "It sounds like the heart and soul of the town.",
            choices = new List<string> { "Continue" },
            nextDialogueIndices = new List<int> { 10 }
        });

        dialogues.Add(new Dialogue
        {
            characterName = "Marilyn Brooks",
            dialogueText = "It truly is. Now, let’s move to the next room where we have our community projects board.",
            choices = new List<string> { "Let's go!" },
            nextDialogueIndices = new List<int> { 11 }
        });

        // Projects Board

        dialogues.Add(new Dialogue
        {
            characterName = "Marilyn Brooks",
            dialogueText = "[At the Projects Board]\nThis board keeps track of all the projects we’re working on. We believe in collective effort, and everyone is encouraged to pitch in.",
            choices = new List<string> { "What kind of projects?" },
            nextDialogueIndices = new List<int> { 12 }
        });

        dialogues.Add(new Dialogue
        {
            characterName = "Player",
            dialogueText = "What kind of projects are listed here?",
            choices = new List<string> { "Continue" },
            nextDialogueIndices = new List<int> { 13 }
        });

        dialogues.Add(new Dialogue
        {
            characterName = "Marilyn Brooks",
            dialogueText = "We have everything from park clean-ups to planning the Festival of Lights. Each project helps improve our town and brings us closer together.",
            choices = new List<string> { "How can I help?" },
            nextDialogueIndices = new List<int> { 14 }
        });

        dialogues.Add(new Dialogue
        {
            characterName = "Player",
            dialogueText = "I’d love to help with some of these projects. How can I get involved?",
            choices = new List<string> { "Continue" },
            nextDialogueIndices = new List<int> { 15 }
        });

        dialogues.Add(new Dialogue
        {
            characterName = "Marilyn Brooks",
            dialogueText = "You’re already on your way by being here. Just speak to any of our project leaders, and they’ll guide you. Now, let’s head out and meet some of our town’s wonderful residents.",
            choices = new List<string> { "Great!" },
            nextDialogueIndices = new List<int> { 16 }
        });

        // Visiting Each NPC's Workplace

        // At the Hospital
        dialogues.Add(new Dialogue
        {
            characterName = "Player",
            dialogueText = "Hi, Dr. Emily! Marilyn told me a lot about you. You must be really busy here.",
            choices = new List<string> { "Continue" },
            nextDialogueIndices = new List<int> { 17 }
        });

        dialogues.Add(new Dialogue
        {
            characterName = "Dr. Emily Carter",
            dialogueText = "Hello! It’s great to meet you. Yes, there’s always something to do at the hospital. We provide all kinds of care, from routine check-ups to emergencies.",
            choices = new List<string> { "It's good to know!" },
            nextDialogueIndices = new List<int> { 18 }
        });

        dialogues.Add(new Dialogue
        {
            characterName = "Player",
            dialogueText = "It’s good to know there’s such a dedicated team here. How do you manage everything?",
            choices = new List<string> { "Continue" },
            nextDialogueIndices = new List<int> { 19 }
        });

        dialogues.Add(new Dialogue
        {
            characterName = "Dr. Emily Carter",
            dialogueText = "It’s a team effort. Everyone here plays a crucial role. If you’re interested, you could help with some of our health initiatives. We’re always looking for volunteers.",
            choices = new List<string> { "I'd like that!" },
            nextDialogueIndices = new List<int> { 20 }
        });

        dialogues.Add(new Dialogue
        {
            characterName = "Player",
            dialogueText = "I’d like that. I think it’s important to contribute to the town’s well-being.",
            choices = new List<string> { "Continue" },
            nextDialogueIndices = new List<int> { 21 }
        });

        dialogues.Add(new Dialogue
        {
            characterName = "Dr. Emily Carter",
            dialogueText = "Exactly. Good health is the foundation of a happy life. Whenever you’re ready, just come by, and we’ll find something for you to do.",
            choices = new List<string> { "Thank you!" },
            nextDialogueIndices = new List<int> { 22 }
        });

        // At the Bakery
        dialogues.Add(new Dialogue
        {
            characterName = "Player",
            dialogueText = "Hi, Eliot! I’ve heard a lot about your bakery. The smell of fresh bread is amazing!",
            choices = new List<string> { "Continue" },
            nextDialogueIndices = new List<int> { 23 }
        });

        dialogues.Add(new Dialogue
        {
            characterName = "Eliot",
            dialogueText = "Welcome! I’m glad you like it. Baking is my passion, and it’s a joy to share it with the town. Today, we’re working on a big order for the upcoming festival.",
            choices = new List<string> { "I'd love to learn!" },
            nextDialogueIndices = new List<int> { 24 }
        });

        dialogues.Add(new Dialogue
        {
            characterName = "Player",
            dialogueText = "That sounds exciting! I’d love to learn how to bake.",
            choices = new List<string> { "Continue" },
            nextDialogueIndices = new List<int> { 25 }
        });

        dialogues.Add(new Dialogue
        {
            characterName = "Eliot",
            dialogueText = "Fantastic! Baking is an art and a science. We mix precision with a lot of love. If you’re interested, we can start with something simple, like apple pies.",
            choices = new List<string> { "I'd enjoy that!" },
            nextDialogueIndices = new List<int> { 26 }
        });

        dialogues.Add(new Dialogue
        {
            characterName = "Player",
            dialogueText = "I’d really enjoy that. I’ll take you up on that offer soon.",
            choices = new List<string> { "Great!" },
            nextDialogueIndices = new List<int> { 27 }
        });

        dialogues.Add(new Dialogue
        {
            characterName = "Eliot",
            dialogueText = "Great! It’s always nice to have an extra pair of hands in the kitchen. Just let me know when you’re ready to roll up your sleeves.",
            choices = new List<string> { "Will do!" },
            nextDialogueIndices = new List<int> { 28 }
        });

        // At the School
        dialogues.Add(new Dialogue
        {
            characterName = "Player",
            dialogueText = "Hello, Madame Rosella! Marilyn says you’re wonderful with the children here.",
            choices = new List<string> { "Continue" },
            nextDialogueIndices = new List<int> { 29 }
        });

        dialogues.Add(new Dialogue
        {
            characterName = "Madame Rosella",
            dialogueText = "Why, thank you! The children are such a joy. We have a lot of fun while learning. It’s a bit of work, but seeing them grow is worth it.",
            choices = new List<string> { "Must be rewarding!" },
            nextDialogueIndices = new List<int> { 30 }
        });

        dialogues.Add(new Dialogue
        {
            characterName = "Player",
            dialogueText = "It must be rewarding. How do you keep them engaged?",
            choices = new List<string> { "Continue" },
            nextDialogueIndices = new List<int> { 31 }
        });

        dialogues.Add(new Dialogue
        {
            characterName = "Madame Rosella",
            dialogueText = "Every day is a new adventure. We mix storytelling, games, and lessons to keep things lively. Maybe you’d like to join us for a class one day? The children love meeting new people.",
            choices = new List<string> { "I'd be happy to!" },
            nextDialogueIndices = new List<int> { 32 }
        });

        dialogues.Add(new Dialogue
        {
            characterName = "Player",
            dialogueText = "I’d be happy to. It sounds like a lot of fun.",
            choices = new List<string> { "Continue" },
            nextDialogueIndices = new List<int> { 33 }
        });

        dialogues.Add(new Dialogue
        {
            characterName = "Madame Rosella",
            dialogueText = "The more, the merrier! And the kids can’t wait to meet you. They always enjoy having someone new to learn from.",
            choices = new List<string> { "Looking forward to it!" },
            nextDialogueIndices = new List<int> { 34 }
        });

        // At the Supermarket
        dialogues.Add(new Dialogue
        {
            characterName = "Player",
            dialogueText = "Hi, Marcus! This place is quite the hub of activity. You must have a lot on your plate running the supermarket.",
            choices = new List<string> { "Continue" },
            nextDialogueIndices = new List<int> { 35 }
        });

        dialogues.Add(new Dialogue
        {
            characterName = "Marcus",
            dialogueText = "Indeed. Keeping the shelves stocked and customers happy is no small task. We’re always busy here, but it’s the lifeline of the town.",
            choices = new List<string> { "Must be a lot of responsibility!" },
            nextDialogueIndices = new List<int> { 36 }
        });

        dialogues.Add(new Dialogue
        {
            characterName = "Player",
            dialogueText = "It must be a lot of responsibility. How do you keep everything running smoothly?",
            choices = new List<string> { "Continue" },
            nextDialogueIndices = new List<int> { 37 }
        });

        dialogues.Add(new Dialogue
        {
            characterName = "Marcus",
            dialogueText = "It’s about staying on top of things and making sure everyone gets what they need. If you’re up for it, there’s always something to do around here. We could use some extra help preparing for the festival.",
            choices = new List<string> { "I'd love to help!" },
            nextDialogueIndices = new List<int> { 38 }
        });

        dialogues.Add(new Dialogue
        {
            characterName = "Player",
            dialogueText = "I’d love to help out. It looks like there’s always something happening here.",
            choices = new List<string> { "Continue" },
            nextDialogueIndices = new List<int> { 39 }
        });

        dialogues.Add(new Dialogue
        {
            characterName = "Marcus",
            dialogueText = "Always. Every little bit helps keep the town running smoothly. Just let me know when you’re ready to pitch in.",
            choices = new List<string> { "Count me in!" },
            nextDialogueIndices = new List<int> { 40 }
        });

        // Back at the Community Center
        dialogues.Add(new Dialogue
        {
            characterName = "Marilyn Brooks",
            dialogueText = "[Back at the Community Center]\nAnd that’s our tour! You’ve met some of the wonderful people who make our town special. How do you feel?",
            choices = new List<string> { "It's amazing!" },
            nextDialogueIndices = new List<int> { 41 }
        });

        dialogues.Add(new Dialogue
        {
            characterName = "Player",
            dialogueText = "It’s amazing. Everyone is so dedicated and welcoming. I’m really looking forward to being part of this community.",
            choices = new List<string> { "Continue" },
            nextDialogueIndices = new List<int> { 42 }
        });

        dialogues.Add(new Dialogue
        {
            characterName = "Marilyn Brooks",
            dialogueText = "I’m glad to hear that. Remember, every small action you take here can make a big difference. Now, let’s see what else you can do to help around town.",
            choices = new List<string> { "Let's go!" },
            nextDialogueIndices = new List<int> { 0 } // Looping back to start or move to the next scene
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
