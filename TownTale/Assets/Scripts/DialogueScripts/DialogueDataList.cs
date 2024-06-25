using System.Collections.Generic;

[System.Serializable]
public class DialogueData
{
    public string id;
    public string characterName;
    public string dialogueText;
    public List<ChoiceData> choices;
}

[System.Serializable]
public class ChoiceData
{
    public string text;
    public int reputationChange;
    public string nextDialogueID; // ID of the next dialogue
}

public static class DialogueDataList
{
    public static List<DialogueData> GetDialogueData()
    {
        return new List<DialogueData>
        {
            // Start Conversation
            new DialogueData
            {
                id = "start",
                characterName = "Player",
                dialogueText = "Hi, Aunt Marilyn! I’m excited to be here. What’s the plan for today?",
                choices = new List<ChoiceData>
                {
                    new ChoiceData { text = "That sounds perfect! Let’s go!", reputationChange = 5, nextDialogueID = "communityCenterTour" },
                    new ChoiceData { text = "Can we skip the tour? I’d rather meet people.", reputationChange = -2, nextDialogueID = "skipTourDecision" }
                }
            },

            // Community Center Tour
            new DialogueData
            {
                id = "communityCenterTour",
                characterName = "Marilyn Brooks",
                dialogueText = "This is the Community Center, the heart of our town. Over there is the hall of history.",
                choices = new List<ChoiceData>
                {
                    new ChoiceData { text = "These old photos are amazing! How old is the town?", reputationChange = 3, nextDialogueID = "historyInsights" },
                    new ChoiceData { text = "It’s just a bunch of old stuff, right?", reputationChange = -3, nextDialogueID = "historySignificance" }
                }
            },

            // Skipping Tour Decision
            new DialogueData
            {
                id = "skipTourDecision",
                characterName = "Marilyn Brooks",
                dialogueText = "Alright, we can go straight to meeting the residents.",
                choices = new List<ChoiceData>
                {
                    new ChoiceData { text = "Insist on Skipping", reputationChange = -5, nextDialogueID = "meetResidents" },
                    new ChoiceData { text = "Fine, let’s do the tour.", reputationChange = 0, nextDialogueID = "communityCenterTour" }
                }
            },

            // History Insights
            new DialogueData
            {
                id = "historyInsights",
                characterName = "Marilyn Brooks",
                dialogueText = "TownTale was founded over a hundred years ago. We’ve kept a lot of our history alive through these exhibits. Each item tells a story about our journey from a small settlement to the vibrant community we are today.",
                choices = new List<ChoiceData>
                {
                    new ChoiceData { text = "What kind of events happen here?", reputationChange = 3, nextDialogueID = "vibrantEvents" },
                    new ChoiceData { text = "Do people even care about this history?", reputationChange = -3, nextDialogueID = "hospitalIntro" }
                }
            },

            // At the Hospital
            new DialogueData
            {
                id = "hospitalIntro",
                characterName = "Player",
                dialogueText = "Hi, Dr. Emily! You must be really busy here.",
                choices = new List<ChoiceData>
                {
                    new ChoiceData { text = "It’s good to have a dedicated team. How can I help?", reputationChange = 5, nextDialogueID = "hospitalHelp" },
                    new ChoiceData { text = "Hospitals seem stressful. How do you manage?", reputationChange = -2, nextDialogueID = "hospitalStress" }
                }
            },
            new DialogueData
            {
                id = "hospitalHelp",
                characterName = "Dr. Emily Carter",
                dialogueText = "Thank you! We are always looking for volunteers to help with our health initiatives.",
                choices = new List<ChoiceData>
                {
                    new ChoiceData { text = "I’d love to help!", reputationChange = 5, nextDialogueID = "endHospital" }
                }
            },
            new DialogueData
            {
                id = "hospitalStress",
                characterName = "Dr. Emily Carter",
                dialogueText = "It can be stressful, but we have a great team that supports each other.",
                choices = new List<ChoiceData>
                {
                    new ChoiceData { text = "That’s good to hear.", reputationChange = 0, nextDialogueID = "endHospital" }
                }
            },

            // At the Bakery
            new DialogueData
            {
                id = "bakeryIntro",
                characterName = "Player",
                dialogueText = "Hi, Eliot! The smell of fresh bread is amazing!",
                choices = new List<ChoiceData>
                {
                    new ChoiceData { text = "I’d love to learn how to bake.", reputationChange = 5, nextDialogueID = "bakeryLearn" },
                    new ChoiceData { text = "Baking every day must be tiring.", reputationChange = -2, nextDialogueID = "bakeryTiring" }
                }
            },
            new DialogueData
            {
                id = "bakeryLearn",
                characterName = "Eliot",
                dialogueText = "I’d be happy to teach you! We can start with something simple, like apple pies.",
                choices = new List<ChoiceData>
                {
                    new ChoiceData { text = "That sounds great!", reputationChange = 5, nextDialogueID = "endBakery" }
                }
            },
            new DialogueData
            {
                id = "bakeryTiring",
                characterName = "Eliot",
                dialogueText = "It can be, but baking is my passion. It’s always rewarding.",
                choices = new List<ChoiceData>
                {
                    new ChoiceData { text = "I see. Maybe I’ll give it a try sometime.", reputationChange = 0, nextDialogueID = "endBakery" }
                }
            },

            // At the School
            new DialogueData
            {
                id = "schoolIntro",
                characterName = "Player",
                dialogueText = "Hello, Madame Rosella! I hear you’re great with the kids.",
                choices = new List<ChoiceData>
                {
                    new ChoiceData { text = "How do you keep them engaged?", reputationChange = 3, nextDialogueID = "schoolEngagement" },
                    new ChoiceData { text = "Kids all day must be exhausting.", reputationChange = -2, nextDialogueID = "schoolExhausting" }
                }
            },
            new DialogueData
            {
                id = "schoolEngagement",
                characterName = "Madame Rosella",
                dialogueText = "We mix storytelling, games, and lessons to keep things lively. Maybe you’d like to join us for a class one day?",
                choices = new List<ChoiceData>
                {
                    new ChoiceData { text = "I’d be happy to!", reputationChange = 3, nextDialogueID = "endSchool" }
                }
            },
            new DialogueData
            {
                id = "schoolExhausting",
                characterName = "Madame Rosella",
                dialogueText = "It can be tiring, but seeing them learn and grow is incredibly rewarding.",
                choices = new List<ChoiceData>
                {
                    new ChoiceData { text = "I can imagine. Maybe I’ll visit sometime.", reputationChange = 0, nextDialogueID = "endSchool" }
                }
            },

            // At the Supermarket
            new DialogueData
            {
                id = "supermarketIntro",
                characterName = "Player",
                dialogueText = "Hi, Marcus! This place is always bustling.",
                choices = new List<ChoiceData>
                {
                    new ChoiceData { text = "How do you manage everything?", reputationChange = 3, nextDialogueID = "supermarketManage" },
                    new ChoiceData { text = "Running a supermarket must get boring.", reputationChange = -2, nextDialogueID = "supermarketBoring" }
                }
            },
            new DialogueData
            {
                id = "supermarketManage",
                characterName = "Marcus",
                dialogueText = "It’s a challenge, but keeping the town supplied is rewarding. Would you like to help with the festival prep?",
                choices = new List<ChoiceData>
                {
                    new ChoiceData { text = "I’d love to help!", reputationChange = 5, nextDialogueID = "endSupermarket" }
                }
            },
            new DialogueData
            {
                id = "supermarketBoring",
                characterName = "Marcus",
                dialogueText = "It has its moments, but there's always something to keep me busy.",
                choices = new List<ChoiceData>
                {
                    new ChoiceData { text = "I see. Maybe I can help sometime.", reputationChange = 0, nextDialogueID = "endSupermarket" }
                }
            },

            // End of specific segments
            new DialogueData
            {
                id = "endHospital",
                characterName = "Narrator",
                dialogueText = "You finish your visit at the hospital and feel more connected to the community.",
                choices = new List<ChoiceData> { new ChoiceData { text = "Continue", reputationChange = 0, nextDialogueID = "end" } } // Link to endDialogue
            },
            new DialogueData
            {
                id = "endBakery",
                characterName = "Narrator",
                dialogueText = "You leave the bakery with a newfound appreciation for Eliot's craft.",
                choices = new List<ChoiceData> { new ChoiceData { text = "Continue", reputationChange = 0, nextDialogueID = "end" } } // Link to endDialogue
            },
            new DialogueData
            {
                id = "endSchool",
                characterName = "Narrator",
                dialogueText = "You leave the school feeling inspired by Madame Rosella's dedication.",
                choices = new List<ChoiceData> { new ChoiceData { text = "Continue", reputationChange = 0, nextDialogueID = "end" } } // Link to endDialogue
            },
            new DialogueData
            {
                id = "endSupermarket",
                characterName = "Narrator",
                dialogueText = "You finish your visit to the supermarket, understanding more about Marcus's daily challenges.",
                choices = new List<ChoiceData> { new ChoiceData { text = "Continue", reputationChange = 0, nextDialogueID = "end" } } // Link to endDialogue
            },

            // Universal End Dialogue
            new DialogueData
            {
                id = "end",
                characterName = "Narrator",
                dialogueText = "This is the end of the conversation. Thank you for playing!",
                choices = new List<ChoiceData>() // No choices, end of dialogue
            }
        };
    }
}
