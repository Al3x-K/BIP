using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewGameManager : MonoBehaviour
{
    public static NewGameManager Instance { get; private set; }
    
    public Hashtable NPCs = new Hashtable();

    public class NPC {
		public string name;
		public string surname;
		public int reputation;
        public string job;
		
		public NPC(string name, string surname, int reputation, string job) {
			this.name = name;
			this.surname = surname;
			this.reputation = reputation;
			this.job = job;
		}
		
		public void increaseReputation(int value = 1) {
			this.reputation = this.reputation + value;
		}
		
		public void decreaseReputation(int value = 1) {
			this.reputation = this.reputation - value;
		}
	}

    void loadDefaultNPCs() {
		// Begone, old data
		NPCs.Clear();
		
		// Creating NPCs
		//NPC Marilyn = new NPC("Marilyn", "Brooks", 2, "Town Counsellor");
		NPC Eliot = new NPC("Eliot", null, 1, "Baker");
		NPC Emily = new NPC("Dr. Emily", "Carter", 1, "Doctor");
		NPC Marcus = new NPC("Marcus", null, 0, "Supermarket Owner");
		NPC Rosella = new NPC("Madame", "Rosella", 1, "Teacher");
		
		// Add each NPC with their name as key
		//NPCs.Add("Marilyn", Marilyn);
		NPCs.Add("Eliot", Eliot);
		NPCs.Add("Emily", Emily);
		NPCs.Add("Marcus", Marcus);
		NPCs.Add("Rosella", Rosella);

        Debug.Log("Loaded Default NPC Data.");
	}

    void PrintNPCs() {
        foreach (DictionaryEntry entry in NPCs) {
            NPC npc = (NPC)entry.Value;
            Debug.Log($"Key: {entry.Key}, Name: {npc.name}, Surname: {npc.surname ?? "N/A"}, Reputation: {npc.reputation}, Job: {npc.job}");
        }
    }

    void PrintReputations() {
        foreach (DictionaryEntry entry in NPCs) {
            NPC npc = (NPC)entry.Value;
            Debug.Log($"Name: {entry.Key}, Reputation: {npc.reputation}");
        }
    }

    void Awake() {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            Debug.Log("Made singleton NewGameManager");
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    
    void Start()
    {
        // Game starts first time, load the default NPCs
        loadDefaultNPCs();
        PrintReputations();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
