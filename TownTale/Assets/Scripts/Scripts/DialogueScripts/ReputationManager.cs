using UnityEngine;

public class ReputationManager : MonoBehaviour
{
    public int ReputationPoints { get; private set; }
    public string CurrentLevel { get; private set; }

    public void AddReputation(int points)
    {
        ReputationPoints += points;
        UpdateReputationLevel();
    }

    private void UpdateReputationLevel()
    {
        if (ReputationPoints < 0) CurrentLevel = "Negative";
        else if (ReputationPoints < 20) CurrentLevel = "Poor";
        else if (ReputationPoints < 50) CurrentLevel = "Neutral";
        else if (ReputationPoints < 80) CurrentLevel = "Good";
        else CurrentLevel = "Exemplary";

        Debug.Log($"Reputation updated to {CurrentLevel} with points: {ReputationPoints}");
    }
}
