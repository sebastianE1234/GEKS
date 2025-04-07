using UnityEngine;

public class JumpingScript : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 7f;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public bool isPlayerOne = true; // Set this in the Inspector per player
    public bool isPlayerTwo = true;

    private Rigidbody2D rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Check if the player is grounded
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);

        bool jumpPressed = false;

        // Check for jump input based on the player
        if (isPlayerOne)
        {
            jumpPressed = Input.GetKeyDown(KeyCode.UpArrow); // Player One uses the Up Arrow key to jump
        }
        else if (isPlayerTwo)
        {
            jumpPressed = Input.GetKeyDown(KeyCode.W); // Player Two uses the 'W' key to jump
        }

        // Handle Jumping
        if (jumpPressed && isGrounded)
        {
            Jump();
        }

        // You can add horizontal movement here if needed
    }

    void Jump()
    {
        // Apply a force upwards for the jump
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
    }
}





