using UnityEngine;

public class TopDownPlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed at which the player moves
    private Vector2 movement; // Store movement input

    void Update()
    {
        // Get input from the player
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        // Move the player
        transform.Translate(movement * moveSpeed * Time.fixedDeltaTime);
    }
}
