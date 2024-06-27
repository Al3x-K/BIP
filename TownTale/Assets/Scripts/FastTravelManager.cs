using UnityEngine;
using UnityEngine.UI;

public class FastTravelManager : MonoBehaviour
{
    public GameObject player;  // Reference to the player GameObject
    public Transform[] fastTravelPoints;  // Array of fast travel points
    public Button[] fastTravelButtons;  // Array of UI buttons for fast travel

    void Start()
    {
        // Add listeners to each button
        for (int i = 0; i < fastTravelButtons.Length; i++)
        {
            int index = i;  // Capture the index in a local variable
            fastTravelButtons[i].onClick.AddListener(() => FastTravel(index));
        }
    }

   void FastTravel(int pointIndex)
{
    if (pointIndex >= 0 && pointIndex < fastTravelPoints.Length)
    {
        Vector3 targetPosition = fastTravelPoints[pointIndex].position;
        Debug.Log($"FastTravel: Moving player to {targetPosition}");
        player.transform.position = targetPosition;
    }
    else
    {
        Debug.LogError("FastTravel: Invalid point index");
    }
}

}
