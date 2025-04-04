using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 7f;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public bool isPlayerOne = true; // Set this in the Inspector for each player

    private Rigidbody2D rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float moveInput = 0f;
        bool jumpPressed = false;

        // Player 1: Arrow keys + Space
        // Player 2: A/D keys + Left Shift
        if (isPlayerOne)
        {
            moveInput = Input.GetAxis("Horizontal");
            jumpPressed = Input.GetKeyDown(KeyCode.Space);
        }
        else
        {
            if (Input.GetKey(KeyCode.A)) moveInput = -1f;
            if (Input.GetKey(KeyCode.D)) moveInput = 1f;
            jumpPressed = Input.GetKeyDown(KeyCode.LeftShift);
        }

        // Movement
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

        // Ground Check
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);

        // Jumping
        if (jumpPressed && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }
}
