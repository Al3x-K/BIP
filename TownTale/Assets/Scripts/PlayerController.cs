using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Vector2 input;
    private Rigidbody2D rb;
    private Animator animator;

    public LayerMask solidObjectsLayer;
    public LayerMask interactableLayer;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        HandleInput();
        HandleMovement();
        HandleInteraction();
    }

    private void HandleInput()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");

        if (input != Vector2.zero)
        {
            animator.SetFloat("moveX", input.x);
            animator.SetFloat("moveY", input.y);
        }

        animator.SetBool("isMoving", input != Vector2.zero);
    }

    private void HandleMovement()
    {
        Vector2 targetPos = rb.position + input * moveSpeed * Time.fixedDeltaTime;

        if (IsWalkable(targetPos))
        {
            rb.MovePosition(targetPos);
        }
    }

    private void HandleInteraction()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Vector2 facingDir = new Vector2(animator.GetFloat("moveX"), animator.GetFloat("moveY"));
            Vector2 interactPos = rb.position + facingDir;

            Collider2D collider = Physics2D.OverlapCircle(interactPos, 0.2f, interactableLayer);
        }
    }

    private bool IsWalkable(Vector2 targetPos)
    {
        // Use multiple raycasts to check for collisions
        float distance = moveSpeed * Time.fixedDeltaTime;
        Vector2 direction = input.normalized;
        
        // Cast rays from head, center, and feet
        Vector2[] raycastOrigins = new Vector2[]
        {
            rb.position + new Vector2(0, 0.5f), // Head
            rb.position,                        // Center
            rb.position - new Vector2(0, 0.5f)  // Feet
        };

        foreach (var origin in raycastOrigins)
        {
            RaycastHit2D hit = Physics2D.Raycast(origin, direction, distance, solidObjectsLayer);
            if (hit.collider != null)
            {
                return false;
            }
        }

        return true;
    }

    private void OnDrawGizmos()
    {
        // Visualize the raycasts in the scene view for debugging
        Gizmos.color = Color.red;
        Vector2 direction = input.normalized;
        float distance = moveSpeed * Time.fixedDeltaTime;

        Vector2[] raycastOrigins = new Vector2[]
        {
            rb.position + new Vector2(0, 0.5f), // Head
            rb.position,                        // Center
            rb.position - new Vector2(0, 0.5f)  // Feet
        };

        foreach (var origin in raycastOrigins)
        {
            Gizmos.DrawLine(origin, origin + direction * distance);
        }
    }
}
