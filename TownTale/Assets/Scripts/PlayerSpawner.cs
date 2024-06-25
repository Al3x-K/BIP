using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            Debug.Log("Player found.");
            if (GameManager.playerPosition != Vector3.zero)
            {
                Debug.Log("Setting player position to: " + GameManager.playerPosition);
                player.transform.position = GameManager.playerPosition;
            }
        }
        else
        {
            Debug.LogError("Player not found!");
        }
    }
}
