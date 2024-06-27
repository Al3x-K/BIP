using System;
using System.Collections.Generic;
using UnityEditor;

[Serializable]
public class DialogueData
{
    public string Id { get; set; }
    public string CharacterName { get; set; }
    public string DialogueText { get; set; }
    public List<ChoiceData> Choices { get; set; }
}

[Serializable]
public class ChoiceData
{
    public string Text { get; set; }
    public int ReputationChange { get; set; }
    public List<string> NextDialogueIDs { get; set; }
    public bool WaitForTrigger { get; set; }
    public string Trigger { get; set; } // Ensure this property is included
}


public static class DialogueDataList
{
    public static List<DialogueData> GetDialogueData()
    {
        return new List<DialogueData>
        {
            CreateStartConversation(),
            CreateTaskIntro(),
            CreateReputationAdvice(),
            CreateMeetEliot(),
            CreateMeetEliot2(),
            CreateEliotGift(),
            CreateMeetEmily(),
            CreateEmilyGift(),
            CreateMeetMarcus(),
            CreateMarcusGift(),
            CreateMeetRosella(),
            CreateRosellaGift(),
            CreateEndDay(),
            CreateEndCampaign(),
            CreateEndDialogue()
        };
    }

    private static DialogueData CreateStartConversation()
    {
        return new DialogueData
        {
            Id = "start",
            CharacterName = "Marilyn Brooks",
            DialogueText = "Hi my dear player_name. Welcome to town tale. Today, you'll start helping with my re-election campaign. I've prepared small gifts for key supporters. You'll likely meet them around town as you go about your day.",
            Choices = new List<ChoiceData>
            {
                new ChoiceData { Text = "I’m ready. Where should I start?", ReputationChange = 0, NextDialogueIDs = new List<string> { "taskIntro" }, WaitForTrigger = false },
                new ChoiceData { Text = "How can I help with your campaign?", ReputationChange = 0, NextDialogueIDs = new List<string> { "reputationAdvice" }, WaitForTrigger = false }
            }
        };
    }

    private static DialogueData CreateTaskIntro()
    {
        return new DialogueData
        {
            Id = "taskIntro",
            CharacterName = "Marilyn Brooks",
            DialogueText = "Why not head to the market? You might bump into Eliot and others there. It’s casual, and you’ll blend right in.",
            Choices = new List<ChoiceData>
            {
                new ChoiceData { Text = "Head to the market.", ReputationChange = 0, NextDialogueIDs = new List<string> { "meetEliot", "meetEmily", "meetMarcus", "meetRosella" }, WaitForTrigger = true }
            }
        };
    }

    private static DialogueData CreateReputationAdvice()
    {
        return new DialogueData
        {
            Id = "reputationAdvice",
            CharacterName = "Marilyn Brooks",
            DialogueText = "Being visible in the community and helping out wherever possible will greatly help my campaign.",
            Choices = new List<ChoiceData>
            {
                new ChoiceData { Text = "Understood. Let’s make a positive impact.", ReputationChange = 0, NextDialogueIDs = new List<string> { "taskIntro" }, WaitForTrigger = false }
            }
        };
    }

    private static DialogueData CreateMeetEliot()
    {
        return new DialogueData
        {
            Id = "meetEliot",
            CharacterName = "Eliot",
            DialogueText = "Hey there! You must be Marilyn's nephew. I baked a cake. Grabbing a quick bite?",
            Choices = new List<ChoiceData>
            {
                new ChoiceData { Text = "Yeah, I'm player_name. You must be Eliot, right?", ReputationChange = 0, NextDialogueIDs = new List<string> { "meetEliot2" }, WaitForTrigger = false },
                new ChoiceData { Text = "No, I have no time. I have to meet the rest of the town.", ReputationChange = 0, NextDialogueIDs = new List<string> { "meetEmily", "meetMarcus", "meetRosella" }, WaitForTrigger = true }
            }
        };
    }

    private static DialogueData CreateMeetEliot2()
    {
        return new DialogueData
        {
            Id = "meetEliot2",
            CharacterName = "Eliot",
            DialogueText = "Hey there! You must be Marilyn's nephew. I baked a cake. Grabbing a quick bite?",
            Choices = new List<ChoiceData>
            {
                new ChoiceData { Text = "Give Eliot his gift.", ReputationChange = 0, NextDialogueIDs = new List<string> { "eliotGift" }, WaitForTrigger = false },
                new ChoiceData { Text = "I'm gonna meet Emily.", ReputationChange = 0, NextDialogueIDs = new List<string> { "meetEmily" }, WaitForTrigger = false }
            }
        };
    }

    private static DialogueData CreateEliotGift()
    {
        return new DialogueData
        {
            Id = "eliotGift",
            CharacterName = "Eliot",
            DialogueText = "Chocolates? Marvelous! Tell Marilyn thanks!",
            Choices = new List<ChoiceData>
            {
                new ChoiceData { Text = "Glad you like them. Take care!", ReputationChange = 0, NextDialogueIDs = new List<string> { "meetEmily" }, WaitForTrigger = false }
            }
        };
    }

    private static DialogueData CreateMeetEmily()
    {
        return new DialogueData
        {
            Id = "meetEmily",
            CharacterName = "Player",
            DialogueText = "Hi, Dr. Emily! How's everything at the hospital?",
            Choices = new List<ChoiceData>
            {
                new ChoiceData { Text = "Give Dr. Emily her gift.", ReputationChange = 5, NextDialogueIDs = new List<string> { "emilyGift" }, WaitForTrigger = false },
                new ChoiceData { Text = "You must be exhausted!", ReputationChange = 0, NextDialogueIDs = new List<string> { "meetMarcus" }, WaitForTrigger = false }
            }
        };
    }

    private static DialogueData CreateEmilyGift()
    {
        return new DialogueData
        {
            Id = "emilyGift",
            CharacterName = "Dr. Emily Carter",
            DialogueText = "How lovely! Please thank her for me.",
            Choices = new List<ChoiceData>
            {
                new ChoiceData { Text = "Glad you like them. Take care!", ReputationChange = 0, NextDialogueIDs = new List<string> { "meetMarcus" }, WaitForTrigger = false }
            }
        };
    }

    private static DialogueData CreateMeetMarcus()
    {
        return new DialogueData
        {
            Id = "meetMarcus",
            CharacterName = "Player",
            DialogueText = "Hey, Marcus! How's business?",
            Choices = new List<ChoiceData>
            {
                new ChoiceData { Text = "Give Marcus his gift.", ReputationChange = 5, NextDialogueIDs = new List<string> { "marcusGift" }, WaitForTrigger = false },
                new ChoiceData { Text = "You're always on the move!", ReputationChange = 0, NextDialogueIDs = new List<string> { "meetRosella" }, WaitForTrigger = false }
            }
        };
    }

    private static DialogueData CreateMarcusGift()
    {
        return new DialogueData
        {
            Id = "marcusGift",
            CharacterName = "Marcus",
            DialogueText = "A cake? Well, it’s the thought that counts. Thanks!",
            Choices = new List<ChoiceData>
            {
                new ChoiceData { Text = "Glad you like it. Take care!", ReputationChange = 0, NextDialogueIDs = new List<string> { "meetRosella" }, WaitForTrigger = false }
            }
        };
    }

    private static DialogueData CreateMeetRosella()
    {
        return new DialogueData
        {
            Id = "meetRosella",
            CharacterName = "Player",
            DialogueText = "Hello, Madame Rosella! How are the kids today?",
            Choices = new List<ChoiceData>
            {
                new ChoiceData { Text = "Give Madame Rosella her gift.", ReputationChange = 5, NextDialogueIDs = new List<string> { "rosellaGift" }, WaitForTrigger = false },
                new ChoiceData { Text = "You have your hands full!", ReputationChange = 0, NextDialogueIDs = new List<string> { "endDay" }, WaitForTrigger = false }
            }
        };
    }

    private static DialogueData CreateRosellaGift()
    {
        return new DialogueData
        {
            Id = "rosellaGift",
            CharacterName = "Madame Rosella",
            DialogueText = "A book? How thoughtful of Marilyn. Thank her for me, please!",
            Choices = new List<ChoiceData>
            {
                new ChoiceData { Text = "Glad you like it. Take care!", ReputationChange = 0, NextDialogueIDs = new List<string> { "endDay" }, WaitForTrigger = false }
            }
        };
    }

    private static DialogueData CreateEndDay()
    {
        return new DialogueData
        {
            Id = "endDay",
            CharacterName = "Player",
            DialogueText = "As the sun sets, you reflect on the productive interactions of the day. Time to report back to Marilyn.",
            Choices = new List<ChoiceData>
            {
                new ChoiceData { Text = "Return and end the day.", ReputationChange = 0, NextDialogueIDs = new List<string> { "endCampaign" }, WaitForTrigger = false }
            }
        };
    }

    private static DialogueData CreateEndCampaign()
    {
        return new DialogueData
        {
            Id = "endCampaign",
            CharacterName = "Marilyn Brooks",
            DialogueText = "Sounds like you made quite the impression today. Well done! Let’s see what tomorrow brings.",
            Choices = new List<ChoiceData>
            {
                new ChoiceData { Text = "Continue", ReputationChange = 0, NextDialogueIDs = new List<string> { "end" }, WaitForTrigger = false }
            }
        };
    }

    private static DialogueData CreateEndDialogue()
    {
        return new DialogueData
        {
            Id = "end",
            CharacterName = "Narrator",
            DialogueText = "This is the end of the conversation. Thank you for playing!",
            Choices = new List<ChoiceData>()
        };
    }
}



/*using System;
using System.Collections.Generic;
using UnityEditor;

[Serializable]
public class DialogueData
{
    public string Id { get; set; }
    public string CharacterName { get; set; }
    public string DialogueText { get; set; }
    public List<ChoiceData> Choices { get; set; }
}

[Serializable]
public class ChoiceData
{
    public string Text { get; set; }
    public int ReputationChange { get; set; }
    public string NextDialogueID { get; set; }
}

public static class DialogueDataList
{
    public static List<DialogueData> GetDialogueData()
    {
        return new List<DialogueData>
        {
            CreateStartConversation(),
            CreateTaskIntro(),
            CreateReputationAdvice(),
            CreateMeetEliot(),
            CreateEliotGift(),
            CreateMeetEmily(),
            CreateEmilyGift(),
            CreateMeetMarcus(),
            CreateMarcusGift(),
            CreateMeetRosella(),
            CreateRosellaGift(),
            CreateEndDay(),
            CreateEndCampaign(),
            CreateEndDialogue()
        };
    }

    private static DialogueData CreateStartConversation()
    {
        return new DialogueData
        {
            Id = "start",
            CharacterName = "Marilyn Brooks",
            DialogueText = "Good morning! Today, you'll start helping with my re-election campaign. I've prepared small gifts for key supporters. You'll likely meet them around town as you go about your day.",
            Choices = new List<ChoiceData>
            {
                new ChoiceData { Text = "I’m ready. Where should I start?", ReputationChange = 0, NextDialogueID = "taskIntro" },
                new ChoiceData { Text = "How can I help improve your reputation?", ReputationChange = 0, NextDialogueID = "reputationAdvice" }
            }
        };
    }

    private static DialogueData CreateTaskIntro()
    {
        return new DialogueData
        {
            Id = "taskIntro",
            CharacterName = "Marilyn Brooks",
            DialogueText = "Why not head to the market? You might bump into Eliot and others there. It’s casual, and you’ll blend right in.",
            Choices = new List<ChoiceData>
            {
                new ChoiceData { Text = "Head to the market.", ReputationChange = 0, NextDialogueID = "meetEliot" }
            }
        };
    }

    private static DialogueData CreateReputationAdvice()
    {
        return new DialogueData
        {
            Id = "reputationAdvice",
            CharacterName = "Marilyn Brooks",
            DialogueText = "Being visible in the community and helping out wherever possible will greatly help my campaign.",
            Choices = new List<ChoiceData>
            {
                new ChoiceData { Text = "Understood. Let’s make a positive impact.", ReputationChange = 0, NextDialogueID = "taskIntro" }
            }
        };
    }

    private static DialogueData CreateMeetEliot()
    {
        return new DialogueData
        {
            Id = "meetEliot",
            CharacterName = "Player",
            DialogueText = "You reach Eliot's food truck just as Dr. Emily is making a purchase. Eliot greets you, 'Hey there! Grabbing a quick bite?'",
            Choices = new List<ChoiceData>
            {
                new ChoiceData { Text = "Give Eliot his gift.", ReputationChange = 5, NextDialogueID = "eliotGift" },
                new ChoiceData { Text = "Just saying hi.", ReputationChange = 0, NextDialogueID = "meetEmily" }
            }
        };
    }

    private static DialogueData CreateEliotGift()
    {
        return new DialogueData
        {
            Id = "eliotGift",
            CharacterName = "Eliot",
            DialogueText = "Chocolates? Marvelous! Tell Marilyn thanks!",
            Choices = new List<ChoiceData>
            {
                new ChoiceData { Text = "Glad you like them. Take care!", ReputationChange = 0, NextDialogueID = "meetEmily" }
            }
        };
    }

    private static DialogueData CreateMeetEmily()
    {
        return new DialogueData
        {
            Id = "meetEmily",
            CharacterName = "Player",
            DialogueText = "Hi, Dr. Emily! How's everything at the hospital?",
            Choices = new List<ChoiceData>
            {
                new ChoiceData { Text = "Give Dr. Emily her gift.", ReputationChange = 5, NextDialogueID = "emilyGift" },
                new ChoiceData { Text = "You must be exhausted!", ReputationChange = 0, NextDialogueID = "meetMarcus" }
            }
        };
    }

    private static DialogueData CreateEmilyGift()
    {
        return new DialogueData
        {
            Id = "emilyGift",
            CharacterName = "Dr. Emily Carter",
            DialogueText = "How lovely! Please thank her for me.",
            Choices = new List<ChoiceData>
            {
                new ChoiceData { Text = "Glad you like them. Take care!", ReputationChange = 0, NextDialogueID = "meetMarcus" }
            }
        };
    }

    private static DialogueData CreateMeetMarcus()
    {
        return new DialogueData
        {
            Id = "meetMarcus",
            CharacterName = "Player",
            DialogueText = "Hey, Marcus! How's business?",
            Choices = new List<ChoiceData>
            {
                new ChoiceData { Text = "Give Marcus his gift.", ReputationChange = 5, NextDialogueID = "marcusGift" },
                new ChoiceData { Text = "You're always on the move!", ReputationChange = 0, NextDialogueID = "meetRosella" }
            }
        };
    }

    private static DialogueData CreateMarcusGift()
    {
        return new DialogueData
        {
            Id = "marcusGift",
            CharacterName = "Marcus",
            DialogueText = "A cake? Well, it’s the thought that counts. Thanks!",
            Choices = new List<ChoiceData>
            {
                new ChoiceData { Text = "Glad you like it. Take care!", ReputationChange = 0, NextDialogueID = "meetRosella" }
            }
        };
    }

    private static DialogueData CreateMeetRosella()
    {
        return new DialogueData
        {
            Id = "meetRosella",
            CharacterName = "Player",
            DialogueText = "Hello, Madame Rosella! How are the kids today?",
            Choices = new List<ChoiceData>
            {
                new ChoiceData { Text = "Give Madame Rosella her gift.", ReputationChange = 5, NextDialogueID = "rosellaGift" },
                new ChoiceData { Text = "You have your hands full!", ReputationChange = 0, NextDialogueID = "endDay" }
            }
        };
    }

    private static DialogueData CreateRosellaGift()
    {
        return new DialogueData
        {
            Id = "rosellaGift",
            CharacterName = "Madame Rosella",
            DialogueText = "A book? How thoughtful of Marilyn. Thank her for me, please!",
            Choices = new List<ChoiceData>
            {
                new ChoiceData { Text = "Glad you like it. Take care!", ReputationChange = 0, NextDialogueID = "endDay" }
            }
        };
    }

    private static DialogueData CreateEndDay()
    {
        return new DialogueData
        {
            Id = "endDay",
            CharacterName = "Player",
            DialogueText = "As the sun sets, you reflect on the productive interactions of the day. Time to report back to Marilyn.",
            Choices = new List<ChoiceData>
            {
                new ChoiceData { Text = "Return and end the day.", ReputationChange = 0, NextDialogueID = "endCampaign" }
            }
        };
    }

    private static DialogueData CreateEndCampaign()
    {
        return new DialogueData
        {
            Id = "endCampaign",
            CharacterName = "Marilyn Brooks",
            DialogueText = "Sounds like you made quite the impression today. Well done! Let’s see what tomorrow brings.",
            Choices = new List<ChoiceData>
            {
                new ChoiceData { Text = "Continue", ReputationChange = 0, NextDialogueID = "end" }
            }
        };
    }

    private static DialogueData CreateEndDialogue()
    {
        return new DialogueData
        {
            Id = "end",
            CharacterName = "Narrator",
            DialogueText = "This is the end of the conversation. Thank you for playing!",
            Choices = new List<ChoiceData>()
        };
    }
}
*/
