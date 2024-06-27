using UnityEngine;

public class PlayerMovementTestDialogue : MonoBehaviour
{


    public float moveSpeed = 5f;
    public LayerMask interactableLayer; // Layer for interactable objects
    private Vector2 moveDirection;
    private Rigidbody2D rb;
    private NPC currentNPC;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Debugging
        if (rb == null)
        {
            Debug.LogError("Rigidbody2D component is not assigned or found!");
        }
    }

    void Update()
    {
        ProcessInputs();
        Move();
        HandleInteraction();
    }

    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        moveDirection = new Vector2(moveX, moveY).normalized;
    }

    void Move()
    {
        if (rb != null)
        {
            rb.MovePosition(rb.position + moveDirection * moveSpeed * Time.deltaTime);
        }
    }

    private void HandleInteraction()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Since there is no Animator, we simply check around the player
            Vector2 interactPos = rb.position + moveDirection;

            Collider2D collider = Physics2D.OverlapCircle(interactPos, 0.2f, interactableLayer);
            if (collider != null && collider.CompareTag("NPC"))
            {
                NPC npc = collider.GetComponent<NPC>();
                if (npc != null)
                {
                    npc.StartDialogue();
                    currentNPC = npc;
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("NPC"))
        {
            NPC npc = collision.GetComponent<NPC>();
            if (npc != null && npc == currentNPC)
            {
                npc.EndDialogue();
                currentNPC = null;
            }
        }
    }
}